using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides functionality to schedule and execute an async task.
    /// </summary>
    public class AsyncTaskExecutor
    {

        /// <summary>
        /// Gets the default <see cref="AppDomain"/>-wide <see cref="AsyncTaskExecutor"/>. This can be updated, but
        /// that should probably be avoided.
        /// </summary>
        public static AsyncTaskExecutor Default { get; set; } = new AsyncTaskExecutor();

        /// <summary>
        /// Executes the action. Returns a <see cref="Task"/> that is completed when the action is completed.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual Task ExecuteAsync(Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return action();
        }

        /// <summary>
        /// Executes the function. Returns a <see cref="Task{TResult}"/> that is completed when the function is completed.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public virtual Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return func();
        }

    }

}
