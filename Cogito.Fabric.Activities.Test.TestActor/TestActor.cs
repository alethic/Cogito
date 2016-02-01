using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;
using Cogito.Fabric.Activities.Test.TestActor.Interfaces;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    class TestActor :
        StatefulActivityActor<TestActorActivity>,
        ITestActor
    {

        public Task Run()
        {
            return RunAsync();
        }

        protected override Activity CreateActivity()
        {
            return new Sequence();
        }

    }

}
