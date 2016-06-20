using System;
using System.Activities;
using System.Threading.Tasks;

using Cogito.ServiceFabric.Activities.Test.TestActor.Interfaces;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.ServiceFabric.Activities.Test.TestActor
{

    [ActorService(Name = "TestActorService")]
    class Test :
        Actor,
        ITest
    {
        public async Task CallBack(ITest2 test2, int value)
        {
            await test2.SetNumber(value);
        }
    }

}
