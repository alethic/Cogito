using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides access to the environment for async operations.
    /// </summary>
    public class AsyncTaskExtension
    {

        static readonly Lazy<AsyncTaskExtension> defaultValue;

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static AsyncTaskExtension()
        {
            defaultValue = new Lazy<AsyncTaskExtension>(() => new AsyncTaskExtension(), true);
        }

        /// <summary>
        /// Gets the default implementation.
        /// </summary>
        public static AsyncTaskExtension Default
        {
            get { return defaultValue.Value; }
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual Task ExecuteAsync(Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return action();
        }

        /// <summary>
        /// Executes the function.
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
