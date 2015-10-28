using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public abstract class ServiceHostBase :
        ServiceControl
    {

        readonly string binPath = ConfigurationSection.GetDefaultSection().BinPath.TrimOrNull();
        readonly string tmpPath = ConfigurationSection.GetDefaultSection().TmpPath.TrimOrNull();

        /// <summary>
        /// Gets the bin path.
        /// </summary>
        public string BinPath
        {
            get { return binPath; }
        }

        /// <summary>
        /// Gets the temporary path.
        /// </summary>
        public string TmpPath
        {
            get { return tmpPath; }
        }

        /// <summary>
        /// Starts the service.
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public abstract bool Start(HostControl hostControl);

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public abstract bool Stop(HostControl hostControl);

    }

}
