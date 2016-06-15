using System;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides a synchronization context linked to an <see cref="ActivityActor"/> timer infrastructure.
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

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityActorSynchronizationContext(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            if (IsInActorContext())
                d(state);
            else
                actor.ScheduleInvokeWithTimer(() => InvokeFromTimer(new SynchronizationContextWorkItem(d, state)));
        }

        /// <summary>
        /// When a scheduled callback is invoked by an actor timer.
        /// </summary>
        Task InvokeFromTimer(SynchronizationContextWorkItem item)
        {
            // schedule further tasks as timers as well
            using (new SynchronizationContextScope(this))
            {
                // invoke callback synchronously
                item.Callback(item.State);
                return Task.FromResult(true);
            }
        }

    }

}
