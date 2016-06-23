using System.Activities;

namespace Cogito.Activities
{

    /// <summary>
    /// Forces children async activities to use the given <see cref="AsyncTaskExecutor"/> to schedule work.
    /// </summary>
    public class AsyncTaskExecutorScope :
        NativeActivity
    {

        readonly Variable<NoPersistHandle> noPersistHandle;
        readonly Variable<AsyncTaskExecutorHandle> executorHandle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncTaskExecutorScope()
        {
            this.noPersistHandle = new Variable<NoPersistHandle>();
            this.executorHandle = new Variable<AsyncTaskExecutorHandle>();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executor"></param>
        public AsyncTaskExecutorScope(AsyncTaskExecutor executor)
            : this()
        {
            Executor = executor;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executor"></param>
        public AsyncTaskExecutorScope(AsyncTaskExecutor executor, Activity body)
            : this(executor)
        {
            Body = body;
        }

        /// <summary>
        /// Body to execute using the given <see cref="AsyncTaskExecutor"/>.
        /// </summary>
        public Activity Body { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AsyncTaskExecutor"/> to use within this scope.
        /// </summary>
        public AsyncTaskExecutor Executor { get; set; }

        /// <summary>
        /// Initializes the activity metadata.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddChild(Body);
            metadata.AddImplementationVariable(noPersistHandle);
            metadata.AddImplementationVariable(executorHandle);
        }

        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            if (Body != null)
            {
                if (Executor != null)
                {
                    context.GetValue(noPersistHandle).Enter(context);

                    // add handle to properties
                    var h = context.GetValue(executorHandle);
                    h.Executor = Executor;
                    context.Properties.Add(h.ExecutionPropertyName, h);
                }

                context.ScheduleActivity(Body, OnBodyComplete);
            }
        }

        /// <summary>
        /// Invoked when the body activity is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnBodyComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            if (Executor != null)
            {
                context.GetValue(noPersistHandle).Exit(context);
                context.GetValue(executorHandle).Executor = null;
            }
        }

    }

    /// <summary>
    /// Forces children async activities to use the given <see cref="AsyncTaskExecutor"/> to schedule work.
    /// </summary>
    public class AsyncTaskExecutorScope<TResult> :
        NativeActivity<TResult>
    {

        readonly Variable<NoPersistHandle> noPersistHandle;
        readonly Variable<AsyncTaskExecutorHandle> executorHandle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncTaskExecutorScope()
        {
            this.noPersistHandle = new Variable<NoPersistHandle>();
            this.executorHandle = new Variable<AsyncTaskExecutorHandle>();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executor"></param>
        public AsyncTaskExecutorScope(AsyncTaskExecutor executor)
            : this()
        {
            Executor = executor;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executor"></param>
        public AsyncTaskExecutorScope(AsyncTaskExecutor executor, Activity<TResult> body)
            : this(executor)
        {
            Body = body;
        }

        /// <summary>
        /// Body to execute using the given <see cref="AsyncTaskExecutor"/>.
        /// </summary>
        public Activity<TResult> Body { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AsyncTaskExecutor"/> to use within this scope.
        /// </summary>
        public AsyncTaskExecutor Executor { get; set; }

        /// <summary>
        /// Initializes the activity metadata.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddChild(Body);
            metadata.AddImplementationVariable(noPersistHandle);
            metadata.AddImplementationVariable(executorHandle);
        }

        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            if (Body != null)
            {
                if (Executor != null)
                {
                    context.GetValue(noPersistHandle).Enter(context);

                    // add handle to properties
                    var h = context.GetValue(executorHandle);
                    h.Executor = Executor;
                    context.Properties.Add(h.ExecutionPropertyName, h);
                }

                context.ScheduleActivity(Body, OnBodyComplete);
            }
        }

        /// <summary>
        /// Invoked when the body activity is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        /// <param name="result"></param>
        void OnBodyComplete(NativeActivityContext context, ActivityInstance completedInstance, TResult result)
        {
            if (Executor != null)
            {
                context.GetValue(noPersistHandle).Exit(context);
                context.GetValue(executorHandle).Executor = null;
            }

            context.SetValue(Result, result);
        }

    }

}
