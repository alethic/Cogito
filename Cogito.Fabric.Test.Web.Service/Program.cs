using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;

namespace Cogito.Fabric.Test.Web.Service
{

    internal static class Program
    {

        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        static void Main()
        {
            try
            {
                using (FabricRuntime fabricRuntime = FabricRuntime.Create())
                {
                    fabricRuntime.RegisterServiceType("OwinStatelessServiceType", typeof(OwinStatelessService));
                    fabricRuntime.RegisterServiceType("OwinStatefulServiceType", typeof(OwinStatefulService));
                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(OwinStatelessService).Name);
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }

    }

}
