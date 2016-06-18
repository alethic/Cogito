using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

using Cogito.Fabric.Activities.Test.TestActor.Interfaces;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    [ActorService(Name = "TestActorService")]
    class Test :
        ActivityActor<TestActorActivity>,
        ITest
    {

        public Task Run()
        {
            return ResumeAsync("Wait1");
        }

        protected override Task OnPersistableIdle()
        {
            return base.OnPersistableIdle();
        }

        protected override Task OnIdle()
        {
            return base.OnIdle();
        }

        protected override Task OnException(Exception exception)
        {
            return base.OnException(exception);
        }

        protected override Task OnAborted(Exception reason)
        {
            return base.OnAborted(reason);
        }

        protected override Task OnFaulted()
        {
            return base.OnFaulted();
        }

        protected override Task OnUnloaded()
        {
            return base.OnUnloaded();
        }

        protected override Task OnCompleted(ActivityInstanceState state, IDictionary<string, object> outputs)
        {
            return base.OnCompleted(state, outputs);
        }

        protected override Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            return base.ReceiveReminderAsync(reminderName, context, dueTime, period);
        }

        protected override TestActorActivity CreateActivity()
        {
            throw new NotImplementedException();
        }
    }

}
