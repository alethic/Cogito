using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
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
        public static AsyncActionActivity Invoke(Func<Task> func, [CallerMemberName] string displayName = null)
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
            return Expressions.Delegate(() => activity);
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

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            return executor(Action);
        }

    }

}
