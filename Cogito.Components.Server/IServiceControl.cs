namespace Cogito.Components.Server
{

    /// <summary>
    /// Provides methods for interacting with the running host.
    /// </summary>
    public interface IServiceControl
    {

        /// <summary>
        /// Signals the service to gracefully shut down.
        /// </summary>
        void Stop();

        /// <summary>
        /// Signals the service to gracefully restart.
        /// </summary>
        void Restart();

    }

}
