using System;

namespace Cogito
{

    /// <summary>
    /// Maintains a reference counted handle to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Ref<T> :
        IDisposable
        where T : class
    {

        readonly RefManager<T> manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        internal Ref(RefManager<T> manager)
        {
            this.manager = manager;
            this.manager.Increment();
        }

        /// <summary>
        /// Gets the referenced value.
        /// </summary>
        public T Value
        {
            get { return manager.Value; }
        }

        public void Dispose()
        {
            manager.Decrement();
        }

    }

}
