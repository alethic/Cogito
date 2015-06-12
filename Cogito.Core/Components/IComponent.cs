using System;

namespace Cogito.Components
{

    /// <summary>
    /// Describes a class that has a defined start and stop state.
    /// </summary>
    public interface IComponent :
        IDisposable
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
