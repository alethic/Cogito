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
                actor.RegisterTimer(InvokeFromTimer, new SynchronizationContextWorkItem(d, state), TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(-1), false);
        }

        /// <summary>
        /// When a scheduled callback is invoked by an actor timer.
        /// </summary>
        Task InvokeFromTimer(object state)
        {
            // schedule further tasks as timers as well
            using (new SynchronizationContextScope(this))
            {
                // invoke callback synchronously
                var item = (SynchronizationContextWorkItem)state;
                item.Callback(item.State);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// Returns <c>true</c> if we're present within the Actor context.
        /// </summary>
        /// <returns></returns>
        bool IsInActorContext()
        {
            return CallContext.LogicalGetData("_FabActCallContext_") != null;
        }

    }

}
