using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCompany.Web.HttpAggregator;

namespace YCompany.WebGateway
{
    static class ServiceCollectionExt
    {
        /// <summary>
        /// AddHttpAggregators
        /// </summary>
        /// <param name="services">container services</param>
        public static void AddHttpAggregator(this IServiceCollection services)
        {
            services.AddTransient<IWebHttpAggregator, WebHttpAggregator>();
        }
    }
}
