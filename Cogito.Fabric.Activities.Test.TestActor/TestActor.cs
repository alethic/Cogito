using System.Threading.Tasks;

using Cogito.Fabric.Activities.Test.TestActor.Interfaces;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    class TestActor :
        StatefulActivityActor<TestActorActivity, object>,
        ITestActor
    {

        public Task Run()
        {
            return ResumeAsync("Wait1");
        }

    }

}
