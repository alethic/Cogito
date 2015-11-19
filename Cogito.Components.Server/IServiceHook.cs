namespace Cogito.Components.Server
{

    /// <summary>
    /// Provides methods to integrate with the service lifetime.
    /// </summary>
    public interface IServiceHook
    {

        /// <summary>
        /// Invoked when the service is starting.
        /// </summary>
        /// <param name="control"></param>
        void OnStarting(IServiceControl control);
        
        /// <summary>
        /// Invoked when the service is started.
        /// </summary>
        /// <param name="control"></param>
        void OnStarted(IServiceControl control);

        /// <summary>
        /// Invoked when the service is stopping.
        /// </summary>
        /// <param name="control"></param>
        void OnStopping(IServiceControl control);

        /// <summary>
        /// Invoked when the service is stopped.
        /// </summary>
        /// <param name="control"></param>
        void OnStopped(IServiceControl control);

    }

}
