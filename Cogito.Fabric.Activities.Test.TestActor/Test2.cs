using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;
using Cogito.Fabric.Activities.Test.TestActor.Interfaces;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    [StatePersistence(StatePersistence.Persisted)]
    class Test2 :
        ActivityActor<Activity, Test2State>,
        ITest2
    {

        protected override Activity CreateActivity()
        {
            return Cogito.Activities.Activities.Sequence(
                Cogito.Activities.Activities.Wait("Run"),
                new While(ctx => true)
                {
                    Body = new Sequence()
                    {
                        Activities =
                        {
                            Cogito.Activities.Activities.Invoke(() => OnLoop()),
                            Cogito.Activities.Activities.Delay(TimeSpan.FromMinutes(1)),
                        }
                    }
                });
        }

        protected override async Task OnActivateAsync()
        {
            if (State == null)
                State = new Test2State();

            await base.OnActivateAsync();
        }

        public Task Run()
        {
            return ResumeAsync("Run");
        }

        public Task<int> GetNumber()
        {
            return Task.FromResult(State.Value);
        }

        async Task OnLoop()
        {
            Console.WriteLine(await GetNumber());
        }

    }

}
