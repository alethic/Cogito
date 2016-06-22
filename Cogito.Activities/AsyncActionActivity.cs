using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity Invoke(Func<Task> func, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity(func)
            {
                DisplayName = displayName,
            };
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncActionActivity :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction(AsyncActionActivity activity)
        {
            return activity != null ? Expressions.Delegate(() => activity) : null;
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        public AsyncActionActivity(Func<Task> action)
            : this()
        {
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<Task> Action { get; set; }

        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            return Action != null ? executor.ExecuteAsync(Action) : null;
        }

    }

}
