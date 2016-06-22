using System.Activities;

namespace Cogito.Activities
{

    public class AsyncTaskExecutorHandle :
        Handle
    {

        /// <summary>
        /// Gets or sets the executor provided by the handle.
        /// </summary>
        public AsyncTaskExecutor Executor { get; set; }

    }

}
