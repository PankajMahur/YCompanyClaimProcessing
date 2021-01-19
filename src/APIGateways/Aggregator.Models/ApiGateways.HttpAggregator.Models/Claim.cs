using System;

namespace ApiGateways.HttpAggregator.Models
{
    public class Claim
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
