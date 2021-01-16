using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Commands;
using YCompany.Library.MicroRabbit.Core.Events;

namespace YCompany.Library.MicroRabbit.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
