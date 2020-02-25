using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public class AsyncLock
    {

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NETCOREAPP3_0

        struct AsyncReleaser : IAsyncDisposable, IDisposable
        {

            readonly AsyncLock lck;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="lck"></param>
            internal AsyncReleaser(AsyncLock lck)
            {
                this.lck = lck;
            }

            /// <summary>
            /// Disposes of the instance.
            /// </summary>
            public ValueTask DisposeAsync()
            {
                if (lck != null)
                    lck.semaphore.Release();

                return new ValueTask(Task.CompletedTask);
            }

            /// <summary>
            /// Disposes of the instance.
            /// </summary>
            public void Dispose()
            {
                if (lck != null)
                    lck.semaphore.Release();
            }

        }

#else

        struct Releaser : IDisposable
        {

            readonly AsyncLock lck;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="lck"></param>
            internal Releaser(AsyncLock lck)
            {
                this.lck = lck;
            }

            public void Dispose()
            {
                if (lck != null)
                    lck.semaphore.Release();
            }

        }

#endif

        readonly SemaphoreSlim semaphore;

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NETCOREAPP3_0
        readonly Task<IAsyncDisposable> lck;
#else
        readonly Task<IDisposable> lck;
#endif

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NETCOREAPP3_0

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncLock()
        {
            semaphore = new SemaphoreSlim(1);
            lck = Task.FromResult<IAsyncDisposable>(new AsyncReleaser(this));
        }

        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<IAsyncDisposable> LockAsync(CancellationToken cancellationToken = default)
        {
            var wait = semaphore.WaitAsync(cancellationToken);
            if (wait.IsCompleted)
                return lck;
            else
                return wait.ContinueWith((_, state) =>
                    (IAsyncDisposable)new AsyncReleaser((AsyncLock)state),
                    this,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }

        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<IAsyncDisposable> LockAsync()
        {
            return LockAsync(CancellationToken.None);
        }

#else

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncLock()
        {
            semaphore = new SemaphoreSlim(1);
            lck = Task.FromResult<IDisposable>(new Releaser(this));
        }

        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<IDisposable> LockAsync(CancellationToken cancellationToken = default)
        {
            var wait = semaphore.WaitAsync(cancellationToken);
            if (wait.IsCompleted)
                return lck;
            else
                return wait.ContinueWith((_, state) =>
                    (IDisposable)new Releaser((AsyncLock)state),
                    this,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }
        
        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<IDisposable> LockAsync()
        {
            return LockAsync(CancellationToken.None);
        }

#endif

    }

}
