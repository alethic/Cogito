using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    /// <summary>
    /// Maintains a reference counted handle to <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// This type should be used. I've exposed it to a number of other Cogito projects that make use of it, for now.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class Ref<T> :
        IDisposable
        where T : class
    {

        RefManager<T> manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        internal Ref(RefManager<T> manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);

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
            var m = manager;
            manager = null;

            if (m != null)
                m.Decrement();
        }

    }

}
