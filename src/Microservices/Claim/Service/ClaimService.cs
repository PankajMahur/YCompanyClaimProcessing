using Claim.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claim.Service
{
    public class ClaimService
    {
        private readonly ClaimRepository _claimRepository;

        public ClaimService(ClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        public IEnumerable<Models.Claim> GetClaims()
        {
            return _claimRepository.GetClaims();
        }
    }
}
