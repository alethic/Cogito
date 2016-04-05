using System;
using System.Threading.Tasks;
using Cogito.Fabric.Http;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

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

        public async Task Connect()
        {
            var client = new ServicePartitionClient<HttpCommunicationClient>(
                HttpCommunicationClientFactory.Default,
                new Uri(new Uri(ApplicationName + "/"), "OwinStatefulService"));
            var o = await client.InvokeWithRetry(async c =>
            {
                return await c.Http.GetAsync(c.BaseAddress);
            }
            );
            o.EnsureSuccessStatusCode();
        }

    }

}
