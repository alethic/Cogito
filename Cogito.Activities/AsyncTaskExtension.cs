namespace Cogito.Activities
{

    /// <summary>
    /// Provides access to the environment for async operations.
    /// </summary>
    public class AsyncTaskExtension
    {

        /// <summary>
        /// Gets the default implementation.
        /// </summary>
        public static AsyncTaskExtension Default { get; private set; } = new AsyncTaskExtension();

        /// <summary>
        /// Locally configured <see cref="AsyncTaskExecutor"/>.
        /// </summary>
        AsyncTaskExecutor executor;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="executor"></param>
        public AsyncTaskExtension(AsyncTaskExecutor executor = null)
        {
            this.executor = executor;
        }

        /// <summary>
        /// Gets the <see cref="AsyncTaskExecutor"/> used for submitting tasks from workflow activities.
        /// </summary>
        public AsyncTaskExecutor Executor
        {
            get { return executor ?? AsyncTaskExecutor.Default; }
            set { executor = value; }
        }

    }

}
