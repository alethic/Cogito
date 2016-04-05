using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Test.Web.Service
{

    [StatePersistence(StatePersistence.Persisted)]
    class TestActor :
        Actor<TestActorState>,
        ITestActor
    {

        protected override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            if (State == null)
                State = new TestActorState();
        }

        public Task IncrementThing()
        {
            return WriteState(() =>
            {
                State.Thing++;
            });
        }

    }

}
