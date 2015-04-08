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

    /// <summary>
    /// Manages the lifecycle of <see cref="IComponent{TIdentity}"/> implementations.
    /// </summary>
    /// <typeparam name="TIdentity"></typeparam>
    public interface IComponentManager<TIdentity> :
        IComponentManager
    {



    }

}
