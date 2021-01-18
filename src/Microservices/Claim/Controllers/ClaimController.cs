using Claim.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claim.Controllers
{
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly ClaimService _claimService;
        

        public ClaimController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        [Route("getClaims")]
        public IActionResult Get()
        {
            return Ok(_claimService.GetClaims());
        }

        [HttpGet]
        [Route("getClaim/{customerId}")]
        public IActionResult GetClaim(string customerId)
        {
            Guid customerIdGuid = Guid.Parse(customerId);
            var testClaim = _claimService.GetClaims().Where(x => x.PolicyCustomerId == customerIdGuid).FirstOrDefault();
            _claimService.Register(testClaim);
            return Ok(_claimService.GetClaims().Where(x=>x.PolicyCustomerId == customerIdGuid).ToList());
        }
    }
}
