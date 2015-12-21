using System.Collections.Concurrent;
using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// <see cref="SynchronizationContext"/> implementation that queues items until run.
    /// </summary>
    public class RunnableSynchronizationContext :
         SynchronizationContext
    {

        readonly ConcurrentQueue<SynchronizationContextWorkItem> queue =
            new ConcurrentQueue<SynchronizationContextWorkItem>();

        /// <summary>
        /// Posts a new work item to the queue.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public override void Post(SendOrPostCallback d, object state)
        {
            queue.Enqueue(new SynchronizationContextWorkItem(d, state));
        }

        /// <summary>
        /// Executes the synchronous work item.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public override void Send(SendOrPostCallback d, object state)
        {
            d(state);
        }

        /// <summary>
        /// Gets the number of work items in the queue.
        /// </summary>
        public int Count
        {
            get { return queue.Count; }
        }

        /// <summary>
        /// Runs the queue until it is empty.
        /// </summary>
        public virtual void Run()
        {
            using (new SynchronizationContextScope(this))
            {
                SynchronizationContextWorkItem item;
                while (queue.TryDequeue(out item))
                    item.Callback(item.State);
            }
        }

        /// <summary>
        /// Runs a single item from the queue.
        /// </summary>
        public virtual void RunOnce()
        {
            using (new SynchronizationContextScope(this))
            {
                SynchronizationContextWorkItem item;
                if (queue.TryDequeue(out item))
                    item.Callback(item.State);
            }
        }

    }

}
