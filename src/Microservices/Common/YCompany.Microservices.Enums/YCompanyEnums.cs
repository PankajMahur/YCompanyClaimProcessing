using System;
using System.Collections.Generic;
using System.Text;

namespace YCompany.Microservices.Enums
{
    public enum PolicyStatus
    {
        Expired = 0,
        Active
    }

    public enum ClaimStatus
    {
        Registered = 0,
        InProgress,
        Queried,
        Resolved
        //...........anything extra
    }
}
