using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Library.MicroRabbit.Core.Commands;
using YCompany.Library.MicroRabbit.Core.Events;

namespace YCompany.Library.RabbitMQ.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        const string MESSAGE_BROKER_NAME = "YCompanyEventBus";
        private readonly IMediator _medidator;
        private readonly IRabbitMQPersistentConnection _rabbitMQPersistentConnection;
        private readonly ILogger<RabbitMQBus> _logger;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly int _retryCount;

        public RabbitMQBus(IMediator mediator, IRabbitMQPersistentConnection rabbitMQPersistentConnection
                                , ILogger<RabbitMQBus> logger, int retryCount = 5)
        {
            _medidator = mediator;
            _rabbitMQPersistentConnection = rabbitMQPersistentConnection;
            _logger = logger;
            _retryCount = retryCount;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public void Publish<T>(T @event) where T : Event
        {
            if (!_rabbitMQPersistentConnection.IsConnected)
            {
                _rabbitMQPersistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", @event.Id, $"{time.TotalSeconds:n1}", ex.Message);
                });
            
            var eventName = @event.GetType().Name;
            
            _logger.LogTrace("Creating RabbitMQ channel to publish event: {EventId} ({EventName})", @event.Id, eventName);
            
            using (var channel = _rabbitMQPersistentConnection.CreateModel())
            {
                _logger.LogTrace("Declaring RabbitMQ exchange to publish event: {EventId}", @event.Id);
                channel.ExchangeDeclare(exchange: MESSAGE_BROKER_NAME, type: "direct");
                channel.QueueDeclare(eventName, false, false, false, null);
                channel.QueueBind(eventName, MESSAGE_BROKER_NAME, eventName, null);
                policy.Execute(() => 
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;                     
                    _logger.LogTrace("Publishing event to RabbitMQ: {EventId}", @event.Id);
                    var message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(
                            exchange: MESSAGE_BROKER_NAME,
                            routingKey: eventName,
                            mandatory: true,
                            basicProperties: properties,
                            body: body);
                });                
            }
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _medidator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
                _eventTypes.Add(typeof(T));

            if (!_handlers.ContainsKey(eventName))
                _handlers.Add(eventName, new List<Type>());

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
                throw new ArgumentException($"Hanlder type {handlerType.Name} already added for '{eventName}'", nameof(handlerType));

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var eventName = typeof(T).Name;
            var channel = CreateConsumerChannel(eventName);            
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.Span);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                var subscriptions = _handlers[eventName];
                foreach (var subscription in subscriptions)
                {
                    var handler = Activator.CreateInstance(subscription);
                    if (handler == null) continue;
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
        }

        private IModel CreateConsumerChannel(string eventName)
        {
            if (!_rabbitMQPersistentConnection.IsConnected)
            {
                _rabbitMQPersistentConnection.TryConnect();
            }

            _logger.LogTrace("Creating RabbitMQ consumer channel");
            var channel = _rabbitMQPersistentConnection.CreateModel();

            channel.ExchangeDeclare(exchange: MESSAGE_BROKER_NAME,
                                    type: "direct");

            channel.QueueDeclare(queue: eventName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.CallbackException += (sender, ea) =>
            {
                //Recreate rabbit mq cosumer channel on exception                
            };

            return channel;
        }

    }
}
