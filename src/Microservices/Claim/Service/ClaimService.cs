using Claim.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Bus;
using YCompany.Microservices.EventSourcing.Commands.Claim;

namespace Claim.Service
{
    public class ClaimService
    {
        private readonly ClaimRepository _claimRepository;
        private readonly IEventBus _eventBus;

        public ClaimService(ClaimRepository claimRepository, IEventBus eventBus)
        {
            _claimRepository = claimRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<Models.Claim> GetClaims()
        {
            return _claimRepository.GetClaims();
        }

        public void Register(Models.Claim registeringClaim)
        {
            var registerClaimCommand = new RegisterClaimCommand()
            {
                 ClaimId = registeringClaim.Id,
                 PolicyCustomerId = registeringClaim.PolicyCustomerId,
                 PolicyId = registeringClaim.PolicyId,
                 RegisterDate = registeringClaim.RegisterDate,
                 Status = registeringClaim.Status                
            };

            _eventBus.SendCommand(registerClaimCommand);
        }
    }
}
