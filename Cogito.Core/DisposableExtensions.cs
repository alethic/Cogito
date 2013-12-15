using System;
using System.Runtime.CompilerServices;

namespace Cogito
{

    public static class DisposableExtensions
    {

        /// <summary>
        /// Values in a ConditionalWeakTable need to be a reference type, so box the reference count int in a class.
        /// </summary>
        class RefCount
        {

            public int count;

        }

        /// <summary>
        /// Provides a disposable that decrements the reference count when disposed of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Disposable<T> :
            IDisposable<T>
            where T : IDisposable
        {

            readonly T resource;
            bool disposed;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="resource"></param>
            public Disposable(T resource)
            {
                this.resource = resource;
                this.resource.Retain();
            }
        
            /// <summary>
            /// Gets the disposable resource.
            /// </summary>
            public T Resource
            {
	            get { return resource; }
            }

            /// <summary>
            /// Disposes of the instance.
            /// </summary>
            public void Dispose()
            {
                if (disposed)
                    return;

                // dispose
                disposed = true;
                resource.Release();
            }

}

        readonly static ConditionalWeakTable<IDisposable, RefCount> refCounts =
            new ConditionalWeakTable<IDisposable, RefCount>();

        /// <summary>
        /// Increments the reference count for the given IDisposable object.
        /// Note: newly instantiated objects don't automatically have a refCount of 1!
        /// If you wish to use ref-counting, always call retain() whenever you want to take ownership of an object.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        /// <param name="disposable">The disposable that should be retained.</param>
        public static void Retain(this IDisposable disposable)
        {
            lock (refCounts)
                refCounts.GetOrCreateValue(disposable).count++;
        }

        /// <summary>
        /// Decrements the reference count for the given disposable.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        /// <param name="disposable">The disposable to release.</param>
        public static void Release(this IDisposable disposable)
        {
            lock (refCounts)
            {
                var refCount = refCounts.GetOrCreateValue(disposable);
                if (refCount.count > 0)
                {
                    refCount.count--;
                    if (refCount.count == 0)
                    {
                        refCounts.Remove(disposable);
                        disposable.Dispose();
                    }
                }
                else
                {
                    // Retain() was never called, so assume there is only
                    // one reference, which is now calling Release()
                    disposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="IDisposable"/> instance that serves as a reference counter for the given object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IDisposable<T> AsReference<T>(this T resource)
            where T : IDisposable
        {
            return new Disposable<T>(resource);
        }

    }

}
