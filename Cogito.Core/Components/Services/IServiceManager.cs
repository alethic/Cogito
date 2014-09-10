namespace Cogito.Components.Services
{

    /// <summary>
    /// Manages interaction with <see cref="IService"/> implementations.
    /// </summary>
    public interface IServiceManager
    {

        /// <summary>
        /// Starts available services.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops available services.
        /// </summary>
        void Stop();

    }

}
