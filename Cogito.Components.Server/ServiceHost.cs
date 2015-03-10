using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public class ServiceHost :
        ServiceControl
    {

        readonly string binPath = ConfigurationSection.GetDefaultSection().BinPath.TrimOrNull();
        readonly string tmpPath = ConfigurationSection.GetDefaultSection().TmpPath.TrimOrNull();
        readonly AppDomainLoader loader;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loader = new AppDomainLoader(binPath, tmpPath);
        }

        public bool Start(HostControl hostControl)
        {
            return loader.Load();
        }

        public bool Stop(HostControl hostControl)
        {
            return loader.Unload();
        }

    }

}
