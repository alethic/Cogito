using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    public interface IStatefulActivityActorInternal :
        IActivityActorInternal
    {

        StatefulActorServiceReplica ActorService { get; }

    }

}
