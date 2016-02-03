using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    public interface IStatelessActivityActorInternal :
        IActivityActorInternal
    {

        StatelessActorServiceInstance ActorService { get; }

    }

}
