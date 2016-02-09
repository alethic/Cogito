using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Internal base implementation of <see cref="StatefulActivityActor"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class StatefulActivityActorBase<TState> :
        Cogito.Fabric.StatefulActor<ActivityActorState<TState>>,
        IRemindable
    {

        /// <summary>
        /// Implements the <see cref="ReceiveReminderAsync(string, byte[], TimeSpan, TimeSpan)"/> method so it can be reimplemented above.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task IRemindable.ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            return ReceiveReminderAsyncHidden(reminderName, context, dueTime, period);
        }

        /// <summary>
        /// New implementation of <see cref="ReceiveReminderAsyncHidden(string, byte[], TimeSpan, TimeSpan)"/>.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected abstract Task ReceiveReminderAsyncHidden(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        /// Overrides the <see cref="CreateDefaultState"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override ActivityActorState<TState> CreateDefaultState()
        {
            return CreateDefaultStateHidden();
        }

        /// <summary>
        /// New implementation of <see cref="CreateDefaultState"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract ActivityActorState<TState> CreateDefaultStateHidden();

        /// <summary>
        /// Overrides the <see cref="OnActivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            await OnActivateAsyncHidden();
        }

        /// <summary>
        /// New implementation of <see cref="OnActivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task OnActivateAsyncHidden();

        /// <summary>
        /// Overrides the <see cref="OnDeactivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override async Task OnDeactivateAsync()
        {
            await base.OnDeactivateAsync();
            await OnDeactivateAsyncHidden();
        }

        /// <summary>
        /// New implementation of <see cref="OnDeactivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task OnDeactivateAsyncHidden();

    }

}
