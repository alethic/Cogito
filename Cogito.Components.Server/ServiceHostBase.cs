using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public abstract class ServiceHostBase :
        ServiceControl
    {

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
