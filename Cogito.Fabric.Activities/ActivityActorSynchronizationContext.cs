using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides a synchronization context linked to an <see cref="ActivityActorCore"/> timer infrastructure.
    /// </summary>
    class ActivityActorSynchronizationContext :
        SynchronizationContext
    {

        /// <summary>
        /// Returns <c>true</c> if we're present within the Actor context.
        /// </summary>
        /// <returns></returns>
        public static bool IsInActorContext()
        {
            return CallContext.LogicalGetData("_FabActCallContext_") != null;
        }

        readonly IActivityActorInternal actor;
        readonly ConcurrentQueue<SynchronizationContextWorkItem> queue;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityActorSynchronizationContext(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
            this.queue = new ConcurrentQueue<SynchronizationContextWorkItem>();
        }

        /// <summary>
        /// Executes or schedules execution of the given callback.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public override void Post(SendOrPostCallback d, object state)
        {
            Schedule(d, state);
        }

        /// <summary>
        /// Schedules the given callback to run at a later time.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        void Schedule(SendOrPostCallback d, object state)
        {
            // add to queue
            queue.Enqueue(new SynchronizationContextWorkItem(d, state));

            // schedule timer on first item
            if (queue.Count == 1)
                actor.ScheduleInvokeWithTimer(() => { Pump(); return Task.FromResult(true); });
        }

        /// <summary>
        /// Executes any deferred tasks.
        /// </summary>
        internal void Pump()
        {
            SynchronizationContextWorkItem item;
            while (queue.TryDequeue(out item))
                Execute(item.Callback, item.State);
        }

        /// <summary>
        /// Executes an item.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        void Execute(SendOrPostCallback d, object state)
        {
            using (var scope = new SynchronizationContextScope(this))
                d(state);
        }

    }

}
