using System;
using System.Threading;

namespace Cogito
{

    /// <summary>
    /// Maintains reference counts around an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RefManager<T> :
        IDisposable
        where T : class
    {

        readonly Func<T> initialize;
        readonly Action<T> dispose;
        T value;
        int count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="initialize"></param>
        /// <param name="dispose"></param>
        public RefManager(Func<T> initialize, Action<T> dispose)
        {
            this.initialize = initialize;
            this.dispose = dispose;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="initialize"></param>
        /// <param name="dispose"></param>
        public RefManager(Func<T> initialize, Action dispose)
            : this(initialize, _ => dispose())
        {

        }

        public T Value
        {
            get { return value; }
        }

        /// <summary>
        /// Obtains a new reference to the value.
        /// </summary>
        /// <returns></returns>
        public Ref<T> Ref()
        {
            return new Ref<T>(this);
        }

        /// <summary>
        /// Increments the reference count, and optionally initializes the value.
        /// </summary>
        internal void Increment()
        {
            if (Interlocked.Increment(ref count) != 0)
                Initialize();
        }

        /// <summary>
        /// Decrements the reference count, and optionally disposes of the value.
        /// </summary>
        internal void Decrement()
        {
            if (Interlocked.Decrement(ref count) == 0)
                Dispose();
        }

        public void Initialize()
        {
            if (initialize != null)
                if (value == null)
                    value = initialize();
        }

        public void Dispose()
        {
            if (dispose != null)
                if (value != null)
                    dispose(value);
        }

    }

}
