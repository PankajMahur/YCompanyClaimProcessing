using System;
using System.Collections.Generic;
using System.Text;
using YCompany.Library.MicroRabbit.Core.Events;
using YCompany.Microservices.Enums;

namespace YCompany.Microservices.EventSourcing.Events.Claim
{
    public class ClaimRegisteredEvent : Event
    {
        public Guid ClaimId { get; set; }

        public Guid PolicyCustomerId { get; set; }

        public Guid PolicyId { get; set; }

        public DateTime RegisterDate { get; set; }

        public ClaimStatus Status { get; set; }
    }
}
