using System.ComponentModel;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStatelessActivityActorInternal :
        IActivityActorInternal
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        StatelessActorServiceInstance ActorService { get; }

    }

}
