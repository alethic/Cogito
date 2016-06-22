using System;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides functionality to schedule and execute a task. This implementation submits to <see cref="Task.Run(Action)"/>.
    /// </summary>
    public class ThreadPoolAsyncTaskExecutor :
        AsyncTaskExecutor
    {

        public override Task ExecuteAsync(Func<Task> action)
        {
            return Task.Run(action);
        }

        public override Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            return Task.Run(func);
        }

    }

}
