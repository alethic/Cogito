using System;
using System.Threading.Tasks;
using Cogito.Fabric.Activities.Test.TestActor.Interfaces;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    class TestActor :
        ActivityActor<TestActorActivity, object>,
        ITestActor
    {

        async Task ITestActor.Run()
        {
            await base.RunAsync();
        }

    }

}
