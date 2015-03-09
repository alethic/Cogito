using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public class ServiceHost :
        ServiceControl
    {

        readonly string basePath = ConfigurationSection.GetDefaultSection().BinPath.TrimOrNull();
        readonly AppDomainLoader loader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loader = new AppDomainLoader(basePath);
        }

        public bool Start(HostControl hostControl)
        {
            loader.Load();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            loader.Unload();
            return true;
        }

    }

}
