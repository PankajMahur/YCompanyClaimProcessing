using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Microservices.EventSourcing.Events.Claim;

namespace YCompany.Microservices.EventSourcing.EventHandlers.Claim
{
    public class RegisterClaimEventHandler : IEventHandler<ClaimRegisteredEvent>
    {
        public Task Handle(ClaimRegisteredEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
