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

        readonly ServiceLoader loader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loader = ContainerManager.GetDefaultTypeResolver().Resolve<ServiceLoader>();
        }

        public override bool Start(HostControl hostControl)
        {
            return loader.Load();
        }

        public override bool Stop(HostControl hostControl)
        {
            return loader.Unload();
        }

    }

}
