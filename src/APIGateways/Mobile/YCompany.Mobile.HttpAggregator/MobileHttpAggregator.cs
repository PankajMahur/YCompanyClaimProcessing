using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YCompany.Mobile.HttpAggregator
{
    public class MobileHttpAggregator : IMobileHttpAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            throw new NotImplementedException();
        }
    }
}
