﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YCompany.Library.MicroRabbit.Core.Events
{
    public abstract class Event
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
        }
        public DateTime Timestamp { get; protected set; }
        public Guid Id { get; protected set; }
    }
}
