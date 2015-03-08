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
        bool disposed;

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
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                foreach (var disposable in attached.OfType<IDisposable>())
                    disposable.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ComponentBase()
        {
            Dispose(false);
        }

    }

}
