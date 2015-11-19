using System;

namespace Cogito.Components
{

    /// <summary>
    /// Default <see cref="IComponent"/> base class.
    /// </summary>
    public abstract class Component :
        IComponent
    {

        bool disposed;

        /// <summary>
        /// Invoked to start the component.
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Invoked to stop the component.
        /// </summary>
        public virtual void Stop()
        {

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

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~Component()
        {
            Dispose(false);
        }

    }

}
