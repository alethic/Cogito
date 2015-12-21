using System;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides internal access to some methods of a <see cref="ActivityActor{TState}"/>.
    /// </summary>
    public interface IActivityActorInternal
    {

        IActorTimer RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period, bool isCallbackReadOnly);

        void UnregisterTimer(IActorTimer timer);

    }

}

