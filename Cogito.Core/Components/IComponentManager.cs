namespace Cogito.Components
{

    /// <summary>
    /// Manages the lifecycle of <see cref="IComponent"/> implementations.
    /// </summary>
    public interface IComponentManager
    {

        /// <summary>
        /// Starts available components.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops available components.
        /// </summary>
        void Stop();

    }

}
