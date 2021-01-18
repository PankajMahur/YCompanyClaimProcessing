using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Microservices.EventSourcing.Commands.Claim;
using YCompany.Microservices.EventSourcing.Events.Claim;

namespace YCompany.Microservices.EventSourcing.EventHandlers.Claim
{
    public class RegisterClaimHandler : IRequestHandler<RegisterClaimCommand, bool>
    {
        private readonly IEventBus _eventBus;
        
        public RegisterClaimHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(RegisterClaimCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new ClaimRegisteredEvent()
            {
                 ClaimId = request.ClaimId,
                 PolicyCustomerId = request.PolicyCustomerId,
                 PolicyId = request.PolicyId,
                 Status = request.Status,
                 RegisterDate = request.RegisterDate
            });
            return Task.FromResult(true);
        }
    }
}
