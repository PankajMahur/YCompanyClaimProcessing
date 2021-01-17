using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YCompany.Microservices.Enums;

namespace Claim.Models
{
    public class Claim
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PolicyCustomerId { get; set; }

        public Guid PolicyId { get; set; }

        public DateTime RegisterDate { get; set; }

        public ClaimStatus Status { get; set; }


    }
}
