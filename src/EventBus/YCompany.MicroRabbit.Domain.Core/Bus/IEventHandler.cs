using System.Threading.Tasks;
using YCompany.Library.MicroRabbit.Core.Events;

namespace YCompany.Library.MicroRabbit.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
       
    }
}
