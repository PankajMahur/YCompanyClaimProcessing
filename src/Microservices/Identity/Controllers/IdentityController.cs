using Identity.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService;
        private readonly JwtService _jwtService;

        public IdentityController(IdentityService identityService, JwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }
        
        [HttpGet]
        [Route("getToken/{firstName}/{lastName}")]
        public IActionResult Get(string firstName, string lastName)
        {
            var policyCustomer =
                    _identityService.GetPolicyCustomers().
                        SingleOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (policyCustomer != null)
            {
                return Ok(_jwtService.GenerateSecurityToken(policyCustomer.CustomerId.ToString()));
            }
            return Ok("User not found. Please try again");
        }

        [HttpGet]
        [Route("getCustomer/{id}")]        
        public IActionResult GetCustomer(string id)
        {
            var guid = Guid.Parse(id);
            var policyCustomer =
                    _identityService.GetPolicyCustomers().
                        SingleOrDefault(x => x.CustomerId== guid);
            if (policyCustomer != null)
            {
                return Ok(policyCustomer);
            }
            return Ok("User not found. Please try again");
        }


    }
}
