using System;
using YCompany.Library.MicroRabbit.Core.Commands;
using YCompany.Microservices.Enums;

namespace YCompany.Microservices.Domain
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
