using System;
using System.Fabric;
using System.Threading;
using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    static class Program
    {

        static void Main()
        {
            try
            {
                using (var fabric = FabricRuntime.Create())
                {
                    fabric.RegisterActor<TestActor>();
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
