using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    /// <summary>
    /// Represents a lock that can be acquired asynchronously.
    /// </summary>
    public sealed class AsyncLock
    {

        /// <summary>
        /// Disposable handle that can release the lock.
        /// </summary>
        public readonly struct AsyncLockHandle : IDisposable
        {

            readonly AsyncLock lck;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="lck"></param>
            internal AsyncLockHandle(AsyncLock lck)
            {
                this.lck = lck ?? throw new ArgumentNullException(nameof(lck));
            }

            /// <summary>
            /// Disposes of the instance, releasing the lock.
            /// </summary>
            public void Dispose()
            {
                if (lck != null)
                    lck.semaphore.Release();
            }

        }

        readonly SemaphoreSlim semaphore;
        readonly Task<AsyncLockHandle> lck;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncLock()
        {
            semaphore = new SemaphoreSlim(1);
            lck = Task.FromResult(new AsyncLockHandle(this));
        }

        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<AsyncLockHandle> LockAsync(CancellationToken cancellationToken = default)
        {
            var wait = semaphore.WaitAsync(cancellationToken);
            if (wait.IsCompleted)
                return lck;
            else
                return wait.ContinueWith((_, state) =>
                    new AsyncLockHandle((AsyncLock)state),
                    this,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }

        /// <summary>
        /// Creates a task which resolves when the lock is free. Dispose of the resulting instance to release the lock.
        /// </summary>
        /// <returns></returns>
        public Task<AsyncLockHandle> LockAsync()
        {
            return LockAsync(CancellationToken.None);
        }

    }

}
