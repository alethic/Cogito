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

        readonly ActivityWorkflowHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="host"></param>
        public ActivityActorAsyncTaskExtension(ActivityWorkflowHost host)
        {
            Contract.Requires<ArgumentNullException>(host != null);

            this.host = host;
        }

        public override Task ExecuteAsync(Func<Task> action)
        {
            return host.Pump.Enqueue(action);
        }

        public override Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            return host.Pump.Enqueue(func);
        }

    }

}
