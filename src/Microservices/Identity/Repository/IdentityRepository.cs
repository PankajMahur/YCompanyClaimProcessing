using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Repository
{
    public class IdentityRepository
    {
        private readonly IdentityDBContext _identityDBContext;

        public IdentityRepository(IdentityDBContext identityDBContext)
        {
            _identityDBContext = identityDBContext;
        }

        public IEnumerable<PolicyCustomer> GetPolicyCustomers()
        {
            return _identityDBContext.PolicyCustomers;
        }
    }
}
