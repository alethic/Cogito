using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public class AsyncLock
    {

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

        readonly SemaphoreSlim semaphore;
        readonly Task<IDisposable> lck;

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

    }

}
