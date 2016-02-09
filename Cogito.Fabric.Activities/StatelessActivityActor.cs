using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Represents a <see cref="StatelessActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>. The <see cref="Activity"/> 
    /// begins running as soon as the <see cref="StatelessActor"/> instance is activated.
    /// </summary>
    public abstract class StatelessActivityActor :
        StatelessActivityActorBase,
        IStatelessActivityActorInternal
    {

        readonly ActivityWorkflowHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected StatelessActivityActor()
            : base()
        {
            host = new ActivityWorkflowHost(this);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Activity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected abstract Activity CreateActivity();

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override async Task OnActivateAsyncHidden()
        {
            await host.OnActivateAsync();
            await OnActivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnActivateAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async Task OnDeactivateAsyncHidden()
        {
            await host.OnDeactivateAsync();
            await OnDeactivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnDeactivateAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        protected Task RunAsync()
        {
            return host.RunAsync();
        }

        /// <summary>
        /// Resumes the <see cref="StatefulActivityActor{TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, value);
        }

        /// <summary>
        /// Resumes the <see cref="StatefulActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName);
        }

        /// <summary>
        /// Invoked when an <see cref="Exception"/> is thrown during the workflow operation.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected virtual Task OnException(Exception exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> goes idle.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is faulted.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnFaulted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is canceled.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCanceled()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is closed.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnClosed()
        {
            return Task.FromResult(true);
        }

        #region IActivityActorInternal

        Activity IActivityActorInternal.CreateActivity()
        {
            return CreateActivity();
        }

        bool IActivityActorInternal.HasState
        {
            get { return false; }
        }

        ActivityActorState IActivityActorInternal.State
        {
            get { throw new NotSupportedException(); }
        }

        IActorTimer IActivityActorInternal.RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period, bool isCallbackReadOnly)
        {
            return RegisterTimer(callback, state, dueTime, period, isCallbackReadOnly);
        }

        void IActivityActorInternal.UnregisterTimer(IActorTimer timer)
        {
            UnregisterTimer(timer);
        }

        bool IActivityActorInternal.CanRegisterReminder
        {
            get { return false; }
        }

        IActorReminder IActivityActorInternal.GetReminder(string reminderName)
        {
            throw new NotSupportedException();
        }

        /// <returns></returns>
        Task<IActorReminder> IActivityActorInternal.RegisterReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period, ActorReminderAttributes attribute)
        {
            throw new NotSupportedException();
        }

        Task IActivityActorInternal.UnregisterReminderAsync(IActorReminder reminder)
        {
            throw new NotSupportedException();
        }

        Task IActivityActorInternal.OnException(Exception exception)
        {
            return OnException(exception);
        }

        Task IActivityActorInternal.OnIdle()
        {
            return OnIdle();
        }

        Task IActivityActorInternal.OnFaulted()
        {
            return OnFaulted();
        }

        Task IActivityActorInternal.OnCanceled()
        {
            return OnCanceled();
        }

        Task IActivityActorInternal.OnClosed()
        {
            return OnClosed();
        }

        #endregion


    }

}
