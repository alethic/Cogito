using System;
using System.Activities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.DurableInstancing;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cogito.Activities;
using Cogito.Collections;
using Cogito.Threading;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// Manages the <see cref="WorkflowApplication"/> associated with a <see cref="Activity"/> actor.
    /// </summary>
    class ActivityWorkflowHost
    {

        internal static readonly XNamespace WorkflowNamespace = "urn:schemas-microsoft-com:System.Activities/4.0/properties";
        internal static readonly XName ActivityTimerExpirationTimeKey = WorkflowNamespace + "TimerExpirationTime";
        internal static readonly string ActivityTimerExpirationReminderName = "Cogito.Fabric.Activities::TimerExpirationReminder";

        readonly IActivityActorInternal actor;
        readonly ConcurrentQueue<Func<Task<bool>>> queue;
        ActivityActorStateManager state;
        WorkflowApplication workflow;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityWorkflowHost(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
            this.queue = new ConcurrentQueue<Func<Task<bool>>>();
        }

        /// <summary>
        /// Enqueues a task to be executed.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        internal Task EnqueueTask(Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            // schedule task on task queue
            var tc = new TaskCompletionSource<bool>();
            queue.Enqueue(() => tc.SafeTrySetFromAsync(action));

            // first task, schedule timer to handle it
            if (queue.Count == 1)
                actor.InvokeWithTimer(PumpTaskQueue);

            // final result to caller
            return tc.Task;
        }

        /// <summary>
        /// Enqueues a task to be executed.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        internal Task<TResult> EnqueueTask<TResult>(Func<Task<TResult>> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            // schedule task on task queue
            var tc = new TaskCompletionSource<TResult>();
            queue.Enqueue(() => tc.SafeTrySetFromAsync(func));

            // first task, schedule timer to handle it
            if (queue.Count == 1)
                actor.InvokeWithTimer(PumpTaskQueue);

            // final result to caller
            return tc.Task;
        }

        /// <summary>
        /// Pumps outstanding tasks in the task queue.
        /// </summary>
        /// <returns></returns>
        async Task PumpTaskQueue()
        {
            Func<Task<bool>> action;
            while (queue.TryDequeue(out action))
                if (!await action())
                    throw new InvalidOperationException("Queued task did not return success.");
        }

        /// <summary>
        /// Invokes the specified method and then pumps any tasks in the queue.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        async Task InvokeAndPump(Func<Task> action)
        {
            var t = action();
            await PumpTaskQueue();
            await t;
        }

        /// <summary>
        /// Invokes the specified method and then pumps any tasks in the queue. 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        async Task<TResult> InvokeAndPump<TResult>(Func<Task<TResult>> func)
        {
            var t = func();
            await PumpTaskQueue();
            return await t;
        }

        /// <summary>
        /// Gets the associated actor.
        /// </summary>
        internal IActivityActorInternal Actor
        {
            get { return actor; }
        }

        /// <summary>
        /// Gets the running workflow application.
        /// </summary>
        internal WorkflowApplication Workflow
        {
            get { return workflow; }
        }

        /// <summary>
        /// Throws if the workflow is in an invalid state.
        /// </summary>
        void ThrowIfInvalidState()
        {
            if (workflow == null)
                throw new ActivityStateException();
        }

        /// <summary>
        /// Creates a new <see cref="ActivityActorStateManager"/>.
        /// </summary>
        Task CreateStateManager()
        {
            state = new ActivityActorStateManager(this);

            state.Persisted = () =>
            {
                EnqueueTask(async () =>
                {
                    await state.SaveAsync();
                    await SaveReminderAsync();
                    await actor.OnPersisted();
                });
            };

            state.Completed = () =>
            {
                EnqueueTask(async () =>
                {
                    await state.SaveAsync();
                    await SaveReminderAsync();
                });
            };

            return Task.FromResult(true);
        }

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="inputs"></param>
        /// <returns></returns>
        Task CreateWorkflow(Activity activity, IDictionary<string, object> inputs = null)
        {
            Contract.Requires<ArgumentNullException>(activity != null);

            // manages access to the workflow state
            workflow = inputs != null ? new WorkflowApplication(activity, inputs) : new WorkflowApplication(activity);
            workflow.InstanceStore = new ActivityActorInstanceStore(state);

            workflow.OnUnhandledException = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnUnhandledException(args);
                });

                return UnhandledExceptionAction.Abort;
            };

            workflow.Aborted = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnAborted(args);
                });
            };

            workflow.PersistableIdle = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnPersistableIdle(args);
                });

                // workflow should save state but not unload until actor deactivated
                // workflow timers invoke themselves as long as it's loaded
                return PersistableIdleAction.Persist;
            };

            workflow.Idle = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnIdle(args);
                });
            };

            workflow.Completed = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnCompleted(args);
                });
            };

            workflow.Unloaded = args =>
            {
                EnqueueTask(async () =>
                {
                    await actor.OnUnloaded(args);
                });
            };

            workflow.Extensions.Add(() => new ActivityActorAsyncTaskExtension(this));
            workflow.Extensions.Add(() => new ActivityActorTrackingParticipant(actor));
            workflow.Extensions.Add(() => new ActivityActorExtension(actor));

            // add user extensions
            foreach (var ext in actor.GetWorkflowExtensions())
                workflow.Extensions.Add(ext);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Attempts to load the workflow if possible.
        /// </summary>
        /// <returns></returns>
        async Task LoadWorkflow()
        {
            // might already be loaded somehow
            if (workflow == null)
            {
                // load state from actor
                await state.LoadAsync();

                // only continue if not already completed
                if (state.InstanceState != InstanceState.Completed)
                {
                    // generate owner ID
                    if (state.InstanceOwnerId == Guid.Empty)
                        state.InstanceOwnerId = Guid.NewGuid();

                    if (state.InstanceId == Guid.Empty)
                    {
                        // clear existing data
                        state.ClearInstanceData();
                        state.ClearInstanceMetadata();

                        // create workflow application
                        await CreateWorkflow(actor.CreateActivity(), actor.CreateActivityInputs() ?? new Dictionary<string, object>());

                        // save new instance ID
                        state.InstanceId = workflow.Id;
                        await state.SaveAsync();

                        // initial invoke
                        await InvokeAndPump(workflow.RunAsync);
                    }
                    else
                    {
                        // create workflow application
                        await CreateWorkflow(actor.CreateActivity());
                        await state.SaveAsync();

                        // load existing instance ID and run
                        await InvokeAndPump(async () => await workflow.LoadAsync(state.InstanceId));
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to unload the workflow if possible.
        /// </summary>
        /// <returns></returns>
        async Task UnloadWorkflow()
        {
            if (workflow != null)
            {
                try
                {
                    await InvokeAndPump(workflow.UnloadAsync);
                }
                catch (TimeoutException)
                {

                }
                finally
                {
                    workflow = null;
                }
            }
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnActivateAsync()
        {
            await CreateStateManager();
            await LoadWorkflow();
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnDeactivateAsync()
        {
            await UnloadWorkflow();
        }

        /// <summary>
        /// Ensures workflow timers are registered for waking the instance up.
        /// </summary>
        /// <returns></returns>
        async Task SaveReminderAsync()
        {
            // next date at which the reminder should be invoked
            var date = (DateTime?)state.GetInstanceData(ActivityTimerExpirationTimeKey.ToString());
            if (date != null)
            {
                // time at which the reminder should be fired, minimum 1 second from now, advance ahead by 1 second
                var dueTime = new TimeSpan(Math.Max(((DateTime)date - DateTime.UtcNow).Ticks, TimeSpan.FromSeconds(1).Ticks))
                    .Add(TimeSpan.FromSeconds(1));

                // unregister reminder if it the time has changed
                var reminder = actor.TryGetReminder(ActivityTimerExpirationReminderName);
                if (reminder != null)
                {
                    // allow a skew of 5 seconds
                    if (Math.Abs((dueTime - reminder.DueTime).TotalSeconds) > 5)
                    {
                        // timer is out of range, will reschedule below
                        await actor.UnregisterReminderAsync(reminder);
                        reminder = null;
                    }
                }

                // schedule new reminder
                if (reminder == null)
                    await actor.RegisterReminderAsync(
                        ActivityTimerExpirationReminderName,
                        null,
                        dueTime,
                        TimeSpan.FromMilliseconds(-1));
            }
            else
            {
                // no reminder required, unregister existing reminder
                var reminder = actor.TryGetReminder(ActivityTimerExpirationReminderName);
                if (reminder != null)
                    await actor.UnregisterReminderAsync(reminder);
            }
        }

        /// <summary>
        /// Resets the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task ResetAsync()
        {
            await UnloadWorkflow();
            state.InstanceId = Guid.Empty;
            state.InstanceState = InstanceState.Unknown;
            state.ClearInstanceData();
            state.ClearInstanceMetadata();
            await state.SaveAsync();
            await LoadWorkflow();
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task RunAsync()
        {
            ThrowIfInvalidState();
            await InvokeAndPump(workflow.RunAsync);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal async Task<BookmarkResumptionResult> ResumeAsync(Bookmark bookmark, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);
            ThrowIfInvalidState();

            return await InvokeAndPump(() => workflow.ResumeBookmarkAsync(bookmark, value, timeout));
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task<BookmarkResumptionResult> ResumeAsync(Bookmark bookmark, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);
            ThrowIfInvalidState();

            return await InvokeAndPump(() => workflow.ResumeBookmarkAsync(bookmark, value));
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal async Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);
            ThrowIfInvalidState();

            return await InvokeAndPump(() => workflow.ResumeBookmarkAsync(bookmarkName, value, timeout));
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);
            ThrowIfInvalidState();

            return await InvokeAndPump(() => workflow.ResumeBookmarkAsync(bookmarkName, value));
        }

        /// <summary>
        /// Invoked when a reminder is fired.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        internal Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName == ActivityTimerExpirationReminderName)
            {
                // workflow was activated, should be good enough
            }

            return Task.FromResult(true);
        }

    }

}
