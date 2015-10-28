using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public class ServiceHost :
        ServiceHostBase
    {

        readonly AppDomainLoader loader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loader = new AppDomainLoader(BinPath, TmpPath);
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
