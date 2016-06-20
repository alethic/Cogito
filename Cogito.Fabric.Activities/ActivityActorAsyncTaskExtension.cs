using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Cogito.Activities;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// <see cref="AsyncTaskExtension"/> implementation that dispatches task execution to the actor timer framework.
    /// </summary>
    class ActivityActorAsyncTaskExtension :
        AsyncTaskExtension
    {

        readonly IActivityActorInternal actor;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityActorAsyncTaskExtension(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        public override Task ExecuteAsync(Func<Task> action)
        {
            return actor.InvokeWithTimerAsync(action);
        }

        public override Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            return actor.InvokeWithTimerAsync(func);
        }

    }

}
