using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCompany.Mobile.HttpAggregator;

namespace YCompany.MobileGateway
{
    public static class ServiceCollectionExt
    {
        public static void AddHttpAggregator(this IServiceCollection services)
        {
            services.AddTransient<IMobileHttpAggregator, MobileHttpAggregator>();
        }
    }
}
