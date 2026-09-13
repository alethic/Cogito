using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    /// <summary>
    /// Manual reset event implementation with async methods.
    /// </summary>
    public class AsyncManualResetEvent
    {

        TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();

        /// <summary>
        /// Waits for the event to be set.
        /// </summary>
        /// <returns></returns>
        public Task WaitAsync()
        {
            return m_tcs.Task;
        }

        /// <summary>
        /// Sets the event.
        /// </summary>
        public void Set()
        {
            m_tcs.TrySetResult(true);
        }

        /// <summary>
        /// Resets the event.
        /// </summary>
        public void Reset()
        {
            while (true)
            {
                var tcs = m_tcs;
                if (!tcs.Task.IsCompleted || Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
                    return;
            }
        }

    }

}
