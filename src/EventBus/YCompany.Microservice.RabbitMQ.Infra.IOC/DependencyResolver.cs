using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Library.RabbitMQ.Infra.Bus;

namespace YCompany.Library.RabbitMQ.Infra.IOC
{
    public static class DependencyResolver
    {
        public static void RegisterEventBusServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Rabbit MQ Connection Factory
            services.AddSingleton<IConnectionFactory>(sp => {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"],
                    //DispatchConsumersAsync = true,
                    UserName = configuration["EventBus:UserName"],
                    Password = configuration["EventBus:Password"]
                };

                return factory;
            });

            //Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //RabittMQ Persistent Connection
            services.AddTransient<IRabbitMQPersistentConnection, DefaultRabbitMQPersistentConnection>();
        }
    }
}
