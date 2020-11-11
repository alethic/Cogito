using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    /// <summary>
    /// Queues functions that return tasks.
    /// </summary>
    public class TaskPump
    {

        readonly ConcurrentQueue<Func<Task<bool>>> queue = new ConcurrentQueue<Func<Task<bool>>>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TaskPump()
        {

        }

        /// <summary>
        /// Invoked when an item is added to the queue.
        /// </summary>
        public EventHandler TaskAdded;

        /// <summary>
        /// Raises the TaskEnqueued event.
        /// </summary>
        void OnTaskAdded()
        {
            TaskAdded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the number of items in the pump.
        /// </summary>
        public int Count
        {
            get { return queue.Count; }
        }

        /// <summary>
        /// Enqueues a task to be executed. Returns a second task that proxies the results of the first.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Task Enqueue(Func<Task> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            // schedule task on task queue
            var tc = new TaskCompletionSource<bool>();
            queue.Enqueue(() => tc.SafeTrySetFromAsync(action));
            OnTaskAdded();
            return tc.Task;
        }

        /// <summary>
        /// Enqueues a task to be executed. Returns a second task that proxies the results of the first.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public Task<TResult> Enqueue<TResult>(Func<Task<TResult>> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            // schedule task on task queue
            var tc = new TaskCompletionSource<TResult>();
            queue.Enqueue(() => tc.SafeTrySetFromAsync(func));
            OnTaskAdded();
            return tc.Task;
        }

        /// <summary>
        /// Pumps a single outstanding task in the task queue.
        /// </summary>
        /// <returns></returns>
        public async Task PumpOneAsync()
        {
            if (queue.TryDequeue(out var action))
                if (!await action())
                    throw new InvalidOperationException("Queued task did not return success.");
        }

        /// <summary>
        /// Pumps outstanding tasks in the task queue.
        /// </summary>
        /// <returns></returns>
        public async Task PumpAsync()
        {
            while (queue.TryDequeue(out var action))
                if (!await action())
                    throw new InvalidOperationException("Queued task did not return success.");
        }

    }

}
