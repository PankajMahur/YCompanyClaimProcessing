using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YCompany.Web.HttpAggregator
{
    internal class WebHttpAggregator : IWebHttpAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            throw new NotImplementedException();
        }
    }
}
