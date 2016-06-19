using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics;
using System.Threading.Tasks;
using Cogito.Fabric.Activities.Test.TestActor.Interfaces;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    [ActorService(Name = "Test2ActorService")]
    [StatePersistence(StatePersistence.Persisted)]
    class Test2 :
        ActivityActor<Activity, Test2State>,
        ITest2
    {

        protected override Activity CreateActivity()
        {
            return Cogito.Activities.Activities.Sequence(
                Cogito.Activities.Activities.Wait("Run"),
                new While(ctx => State.Value < 10)
                {
                    Body = new Sequence()
                    {
                        Activities =
                        {
                            Cogito.Activities.Activities.Invoke(() => OnLoop()),
                            Cogito.Activities.Activities.Delay(TimeSpan.FromSeconds(5)),
                        }
                    }
                });
        }

        public Task Run()
        {
            return ResumeAsync("Run");
        }

        public Task<int> GetNumber()
        {
            return Task.FromResult(State.Value);
        }

        public Task SetNumber(int number)
        {
            State.Value = number;
            return Task.FromResult(true);
        }

        Task OnLoop()
        {
            State.Value--;
            Debug.WriteLine(ServiceContext.NodeContext.NodeName + ":" + State.Value);
            return Task.FromResult(true);
        }

    }

}
