using System;
using System.Collections.Generic;
using System.Text;
using YCompany.MicroRabbit.Domain.Core.Events;

namespace YCompany.MicroRabbit.Domain.Core.Commands
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
