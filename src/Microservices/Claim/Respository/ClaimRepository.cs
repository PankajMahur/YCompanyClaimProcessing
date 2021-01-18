using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Claim.Models;

namespace Claim.Respository
{
    public class ClaimRepository
    {
        private readonly ClaimDbContext _claimDbContext;

        public ClaimRepository(ClaimDbContext claimDbContext)
        {
            _claimDbContext = claimDbContext;
        }

        public IEnumerable<Models.Claim> GetClaims()
        {
            return _claimDbContext.Claims;
        }
    }
}
