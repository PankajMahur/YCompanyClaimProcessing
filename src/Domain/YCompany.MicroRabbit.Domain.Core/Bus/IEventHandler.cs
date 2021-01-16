using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCompany.MicroRabbit.Domain.Core.Events;

namespace YCompany.MicroRabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handler(TEvent @event);
    }

    public interface IEventHandler
    { }
}
