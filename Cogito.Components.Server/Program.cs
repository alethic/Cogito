using Topshelf;

namespace Cogito.Components.Server
{

    public static class Program
    {

        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Main(string[] args)
        {
            return (int)HostFactory.Run(x =>
            {
                x.Service<ServiceHost>(() => new ServiceHost());
                x.SetServiceName("Cogito.Components.Server");
                x.StartAutomatically();
                x.EnableServiceRecovery(c => c.RestartService(5));
                x.RunAsNetworkService();
            });
        }

    }

}
