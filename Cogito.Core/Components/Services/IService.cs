using Cogito.Components;

namespace Cogito.Components.Services
{

    /// <summary>
    /// Describes a component that initializes itself at application start.
    /// </summary>
    public interface IService :
        IComponent
    {

        /// <summary>
        /// Starts the service.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the service.
        /// </summary>
        void Stop();

    }

}
