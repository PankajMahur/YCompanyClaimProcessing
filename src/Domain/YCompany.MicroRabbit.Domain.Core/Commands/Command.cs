using System;
using YCompany.Library.MicroRabbit.Core.Events;

namespace YCompany.Library.MicroRabbit.Core.Commands
{
    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; protected set; }
    }
}
