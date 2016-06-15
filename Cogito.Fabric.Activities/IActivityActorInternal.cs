using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides access to some methods of a <see cref="Actor"/> that can host a <see cref="Activity"/>.
    /// </summary>
    interface IActivityActorInternal
    {

        /// <summary>
        /// Gets the ID of the actor.
        /// </summary>
        ActorId Id { get; }

        /// <summary>
        /// Gets the <see cref="ActorService"/>.
        /// </summary>
        ActorService ActorService { get; }

        /// <summary>
        /// Gets a reference to the <see cref="IActorStateManager"/>.
        /// </summary>
        IActorStateManager StateManager { get; }

        /// <summary>
        /// Creates the <see cref="Activity"/> associated with the actor.
        /// </summary>
        /// <returns></returns>
        Activity CreateActivity();

        /// <summary>
        /// Creates the set of parameters to be passed to the workflow.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> CreateActivityInputs();

        /// <summary>
        /// Gets the set of custom extensions to add to the workflow.
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetWorkflowExtensions();

        /// <summary>
        /// Registers a timer with the actor.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        IActorTimer RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        /// Unregisters a timer with the actor.
        /// </summary>
        /// <param name="timer"></param>
        void UnregisterTimer(IActorTimer timer);

        /// <summary>
        /// Gets the reminder with the specified name.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <returns></returns>
        IActorReminder GetReminder(string reminderName);

        /// <summary>
        /// Registers the specified reminder.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<IActorReminder> RegisterReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        ///  Unregisters the specified reminder.
        /// </summary>
        /// <param name="reminder"></param>
        /// <returns></returns>
        Task UnregisterReminderAsync(IActorReminder reminder);

        /// <summary>
        /// Invoked when the activity workflow is persisted to the <see cref="IActorStateManager"/>.
        /// </summary>
        /// <returns></returns>
        Task OnPersisted();

        /// <summary>
        /// Invoked when an unhandled <see cref="Exception"/> occurs.
        /// </summary>
        /// <param name="unhandledException"></param>
        /// <returns></returns>
        Task OnException(Exception unhandledException);

        /// <summary>
        /// Invoked when the workflow is aborted.
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        Task OnAborted(Exception reason);

        /// <summary>
        /// Invoked when the workflow goes idle.
        /// </summary>
        /// <returns></returns>
        Task OnIdle();

        /// <summary>
        /// Invoked when the workflow goes idle and is persitable.
        /// </summary>
        /// <returns></returns>
        Task OnPersistableIdle();

        /// <summary>
        /// Invoked when the workflow is faulted.
        /// </summary>
        /// <returns></returns>
        Task OnFaulted();

        /// <summary>
        /// Invoked when the workflow is completed.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="outputs"></param>
        /// <returns></returns>
        Task OnCompleted(ActivityInstanceState state, IDictionary<string, object> outputs);

        /// <summary>
        /// Invoked when the workflow is unloaded.
        /// </summary>
        /// <returns></returns>
        Task OnUnloaded();

    }

}

