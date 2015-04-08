using System;
using System.Collections.Generic;

namespace Cogito.ServiceBus
{

    public interface IFault
    {

        string FaultType { get; }

        List<string> Messages { get; }

        DateTime OccurredAt { get; }

        List<string> StackTrace { get; }

    }

    public interface IFault<T> :
        IFault
        where T : class
    {



    }

}
