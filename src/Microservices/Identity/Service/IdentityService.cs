using Identity.Models;
using Identity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Service
{
    public class IdentityService
    {
        private readonly IdentityRepository _identityRepository;

        public IdentityService(IdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public IEnumerable<PolicyCustomer> GetPolicyCustomers()
        {
            return _identityRepository.GetPolicyCustomers();
        }
    }
}
