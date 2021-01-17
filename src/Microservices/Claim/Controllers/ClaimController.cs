﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly ClaimDbContext _claimDbContext;
        

        public ClaimController(ClaimDbContext claimDbContext)
        {
            _claimDbContext = claimDbContext;
        }

        [HttpGet]
        [Route("getClaims")]
        public IActionResult Get()
        {
            return Ok(_claimDbContext.Claims.ToList());
        }
    }
}
