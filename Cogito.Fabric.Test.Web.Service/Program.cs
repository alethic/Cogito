using System;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Cogito.Fabric.Test.Web.Service
{

    static class Program
    {

        static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync("OwinStatelessServiceType", ctx => new OwinStatelessService(ctx));
                ServiceRuntime.RegisterServiceAsync("OwinStatefulServiceType", ctx => new OwinStatefulService(ctx));
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }

}
