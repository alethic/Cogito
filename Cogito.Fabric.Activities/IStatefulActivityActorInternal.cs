using System.ComponentModel;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStatefulActivityActorInternal :
        IActivityActorInternal
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        StatefulActorServiceReplica ActorService { get; }

    }

}
