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

        [TestMethod]
        public void Test_ActivityActorInstanceStore_Delay()
        {
            Task.Run(async () =>
            {
                var actor = new ActorStateManagerMock();
                var state = new ActivityActorStateManager(() => actor);
                var store = new ActivityActorInstanceStore(state);

                await state.SetInstanceOwnerId(Guid.NewGuid());

                var workflow = new WorkflowApplication(
                    Cogito.Activities.Activities.Sequence(
                        Cogito.Activities.Activities.Delay(TimeSpan.FromSeconds(5)),
                        Cogito.Activities.Activities.Invoke(() => Console.WriteLine("End"))));
                workflow.SynchronizationContext = new SynchronousSynchronizationContext();
                workflow.InstanceStore = store;
                workflow.OnUnhandledException = args =>
                {
                    Assert.Fail(args.UnhandledException.Message);
                    return UnhandledExceptionAction.Abort;
                };
                workflow.PersistableIdle = args => PersistableIdleAction.Unload;
                workflow.Idle = args => { };
                await state.SetInstanceId(workflow.Id);

                await workflow.RunAsync();

                Assert.IsNotNull(await state.GetInstanceData<DateTime?>(ActivityWorkflowHost.ActivityTimerExpirationTimeKey));

                await Task.Delay(TimeSpan.FromSeconds(7));

                await workflow.RunAsync();
                await workflow.PersistAsync();

                Assert.IsNull(await state.GetInstanceData<DateTime?>(ActivityWorkflowHost.ActivityTimerExpirationTimeKey));
            }).Wait();
        }

    }

}
