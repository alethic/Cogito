using System;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Components
{

    /// <summary>
    /// Describes a simple component that manages it's lifetime.
    /// </summary>
    public abstract class ComponentBase :
        IComponent
    {

        readonly LinkedList<object> attached;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ComponentBase()
        {
            this.attached = new LinkedList<object>();
        }

        /// <summary>
        /// Adds an object to be disposed with this component.
        /// </summary>
        /// <param name="value"></param>
        public void Attach(object value)
        {
            attached.AddLast(value);
        }

        /// <summary>
        /// Adds an object to be disposed with this component.
        /// </summary>
        /// <param name="disposable"></param>
        public void Attach(IDisposable disposable)
        {
            Attach((object)disposable);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            foreach (var disposable in attached.OfType<IDisposable>())
                disposable.Dispose();
        }

    }

}
