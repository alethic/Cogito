using System.Collections.Concurrent;
using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// <see cref="SynchronizationContext"/> implementation that restores a <see cref="ExecutionContext"/> to its
    /// tasks.
    /// </summary>
    public class QueuedSynchronizationContext :
         SynchronizationContext
    {

        readonly ConcurrentQueue<QueuedSynchronizationContextTask> queue;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public QueuedSynchronizationContext()
        {
            this.queue = new ConcurrentQueue<QueuedSynchronizationContextTask>();
        }

        public override SynchronizationContext CreateCopy()
        {
            return new QueuedSynchronizationContext();
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            queue.Enqueue(new QueuedSynchronizationContextTask(d, state));
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            queue.Enqueue(new QueuedSynchronizationContextTask(d, state));
        }

        /// <summary>
        /// Dequeues the next task to be executed.
        /// </summary>
        /// <returns></returns>
        public QueuedSynchronizationContextTask Dequeue()
        {
            QueuedSynchronizationContextTask task;
            if (queue.TryDequeue(out task))
                return task;

            return null;
        }

    }

}
