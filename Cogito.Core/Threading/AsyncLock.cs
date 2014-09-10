using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public class AsyncLock
    {

        struct Releaser :
            IDisposable
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

        public Task<IDisposable> LockAsync()
        {
            var wait = semaphore.WaitAsync();
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

    }

}
