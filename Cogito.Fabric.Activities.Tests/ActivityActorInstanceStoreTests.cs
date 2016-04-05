using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;
using Cogito.Activities;
using Cogito.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Fabric.Activities.Tests
{

    [TestClass]
    public class ActivityActorInstanceStoreTests
    {

        [TestMethod]
        public void Test_ActivityActorInstanceStore()
        {
            var actor = new ActorStateManagerMock();
            var state = new ActivityActorStateManager(() => actor);
            var store = new ActivityActorInstanceStore(state);
        }

        [TestMethod]
        public void Test_ActivityActorInstanceStore_Run()
        {
            Task.Run(async () =>
            {
                var actor = new ActorStateManagerMock();
                var state = new ActivityActorStateManager(() => actor);
                var store = new ActivityActorInstanceStore(state);

                await state.SetInstanceOwnerId(Guid.NewGuid());

                var workflow = new WorkflowApplication(new Sequence());
                workflow.InstanceStore = store;
                await workflow.RunAsync();
            }).Wait();
        }

    }

}
