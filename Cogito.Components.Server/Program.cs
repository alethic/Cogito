using System;
using System.Diagnostics.Contracts;

using Topshelf;
using Topshelf.HostConfigurators;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Entry point for the Cogito Server application. This class can be extended if desired.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Main(string[] args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            return new Program().Run(args);
        }

        /// <summary>
        /// Runs the program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual int Run(string[] args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            return (int)CreateHost(args).Run();
        }

        /// <summary>
        /// Builds a new <see cref="Host"/>.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Host CreateHost(string[] args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            return HostFactory.New(x => ConfigureHost(args, x));
        }

        /// <summary>
        /// Applies the configuration to the given <see cref="HostConfigurator"/>.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="x"></param>
        protected virtual void ConfigureHost(string[] args, HostConfigurator x)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Contract.Requires<ArgumentNullException>(x != null);

            x.Service(CreateServiceHost);
            x.SetServiceName(GetServiceName());
            x.StartAutomatically();
            x.EnableServiceRecovery(c => c.RestartService(5).SetResetPeriod(0));
            x.EnableShutdown();
            x.RunAsNetworkService();
        }

        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetServiceName()
        {
            return "Cogito.Components.Server";
        }

        /// <summary>
        /// Creates the <see cref="ServiceHost"/> instance.
        /// </summary>
        /// <returns></returns>
        protected virtual ServiceHost CreateServiceHost()
        {
            return new ServiceHost();
        }

    }

}
