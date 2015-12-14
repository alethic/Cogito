using System;
using System.Diagnostics.Contracts;

using Cogito.Composition.Hosting;

using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public class ServiceHost :
        ServiceHostBase
    {

        /// <summary>
        /// <see cref="IServiceControl"/> instance that wraps Topshelf.
        /// </summary>
        class ServiceControl :
            IServiceControl
        {

            readonly HostControl host;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="host"></param>
            public ServiceControl(HostControl host)
            {
                Contract.Requires<ArgumentNullException>(host != null);

                this.host = host;
            }

            public void Stop()
            {
                host.Stop();
            }

            public void Restart()
            {
                host.Restart();
            }

        }

        readonly ServiceManager loader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loader = ContainerManager.GetDefaultTypeResolver().Resolve<ServiceManager>();
        }

        public override bool Start(HostControl hostControl)
        {
            return loader.Start(new ServiceControl(hostControl));
        }

        public override bool Stop(HostControl hostControl)
        {
            return loader.Stop(new ServiceControl(hostControl));
        }

    }

}
