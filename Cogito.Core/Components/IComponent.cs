using System;

namespace Cogito.Components
{

    /// <summary>
    /// Describes a component with lifetime management.
    /// </summary>
    public interface IComponent :
        IDisposable
    {

        /// <summary>
        /// Adds a <see cref="IDisposable"/> to be disposed when the component is disposed.
        /// </summary>
        /// <param name="disposable"></param>
        void Attach(IDisposable disposable);

    }

}
