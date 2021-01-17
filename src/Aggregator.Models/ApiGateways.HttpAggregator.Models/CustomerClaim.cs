using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGateways.HttpAggregator.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
