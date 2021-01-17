using ApiGateways.HttpAggregator.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Configuration;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YCompany.Web.HttpAggregator
{
    public class WebHttpAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var policyCustomerResponse =  await responses
                                            .FirstOrDefault(r => ((DownstreamRoute)r.Items["DownstreamRoute"]).Key == "PolicyUser")
                                                .Items.DownstreamResponse().Content.ReadAsStringAsync();

            var policyClaimResponse = await responses
                                           .FirstOrDefault(r => ((DownstreamRoute)r.Items["DownstreamRoute"]).Key == "PolicyClaim")
                                               .Items.DownstreamResponse().Content.ReadAsStringAsync();


            var user = JsonConvert.DeserializeObject<Customer>(policyCustomerResponse);
            user.Claims = JsonConvert.DeserializeObject<List<Claim>>(policyClaimResponse);

            var claimsOfUser = JsonConvert.SerializeObject(user);

            var stringContent = new StringContent(claimsOfUser)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
