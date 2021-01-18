using System;
using System.Collections.Generic;
using System.Text;
using YCompany.Library.MicroRabbit.Core.Commands;
using YCompany.Microservices.Enums;

namespace YCompany.Microservices.EventSourcing.Commands.Claim
{
    public abstract class ClaimCommand : Command
    {
        public Guid ClaimId { get; set; }

        public Guid PolicyCustomerId { get;  set; }

        public Guid PolicyId { get; set; }

        public DateTime RegisterDate { get; set; }

        public ClaimStatus Status { get; set; }
    }
}
