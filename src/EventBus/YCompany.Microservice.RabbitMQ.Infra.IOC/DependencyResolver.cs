using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Library.RabbitMQ.Infra.Bus;

namespace YCompany.Library.RabbitMQ.Infra.IOC
{
    public class DependencyResolver
    {
        public static void RegisterEventBusServices(IServiceCollection services)
        {
            //Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
