using Topshelf;
using Topshelf.HostConfigurators;

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
            return (int)BuildHost(args).Run();
        }

        /// <summary>
        /// Builds a new <see cref="Host"/>.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Host BuildHost(string[] args)
        {
            return HostFactory.New(x => ConfigureHostFactory(args, x));
        }

        /// <summary>
        /// Applies the configuration to the given <see cref="HostConfigurator"/>.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="x"></param>
        public static void ConfigureHostFactory(string[] args, HostConfigurator x)
        {
            x.Service<ServiceHost>(() => new ServiceHost());
            x.SetServiceName("Cogito.Components.Server");
            x.StartAutomatically();
            x.EnableServiceRecovery(c => c.RestartService(5));
            x.RunAsNetworkService();
        }

    }

}
