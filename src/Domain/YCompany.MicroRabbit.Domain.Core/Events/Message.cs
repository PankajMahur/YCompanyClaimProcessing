using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YCompany.Library.MicroRabbit.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }
        public string MessageType  { get; protected set; }
    }
}
