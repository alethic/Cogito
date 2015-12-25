using System;
using System.Activities;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides internal access to some methods of a an <see cref="Activity"/> actor.
    /// </summary>
    public interface IActivityActorInternal
    {

        /// <summary>
        /// Gets whether the actor supports state.
        /// </summary>
        bool HasState { get; }

        /// <summary>
        /// Gets a reference to the <see cref="ActivityActorState"/>.
        /// </summary>
        ActivityActorState State { get; }

        /// <summary>
        /// Creates the <see cref="Activity"/> associated with the actor.
        /// </summary>
        /// <returns></returns>
        Activity CreateActivity();

        /// <summary>
        /// Registers a timer with the actor.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <param name="isCallbackReadOnly"></param>
        /// <returns></returns>
        IActorTimer RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period, bool isCallbackReadOnly);

        /// <summary>
        /// Unregisters a timer with the actor.
        /// </summary>
        /// <param name="timer"></param>
        void UnregisterTimer(IActorTimer timer);

        /// <summary>
        /// Gets whether or not the actor can register reminders.
        /// </summary>
        bool CanRegisterReminder { get; }

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
        /// <param name="attribute"></param>
        /// <returns></returns>
        Task<IActorReminder> RegisterReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period, ActorReminderAttributes attribute);

        /// <summary>
        //  Unregisters the specified reminder.
        /// </summary>
        /// <param name="reminder"></param>
        /// <returns></returns>
        Task UnregisterReminderAsync(IActorReminder reminder);

        /// <summary>
        /// Invoked when an unhandled <see cref="Exception"/> occurs.
        /// </summary>
        /// <param name="unhandledException"></param>
        /// <returns></returns>
        Task OnException(Exception unhandledException);

        /// <summary>
        /// Invoked when the workflow goes idle.
        /// </summary>
        /// <returns></returns>
        Task OnIdle();

        /// <summary>
        /// Invoked when the workflow is faulted.
        /// </summary>
        /// <returns></returns>
        Task OnFaulted();

        /// <summary>
        /// Invoked when the workflow is canceled.
        /// </summary>
        /// <returns></returns>
        Task OnCanceled();

        /// <summary>
        /// Invoked when the workflow is closed.
        /// </summary>
        /// <returns></returns>
        Task OnClosed();

    }

}

