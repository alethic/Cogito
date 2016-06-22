using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ActionActivity Invoke(Action action, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity(action)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Appends <paramref name="action"/> to be executed after the <see cref="Activity"/>.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Sequence Then(this Activity activity, Action action)
        {
            return Then(activity, new ActionActivity(action));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public partial class ActionActivity :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Converts a <see cref="ActionActivity"/> into an <see cref="ActivityAction"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction(ActionActivity activity)
        {
            return activity != null ? Expressions.Delegate(() => activity) : null;
        }

        /// <summary>
        /// Convers a <see cref="ActionActivity"/> into a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        public ActionActivity(Action action)
            : this()
        {
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action Action { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            return Action != null ? executor.ExecuteAsync(() => { Action(); return Task.FromResult(true); }) : null;
        }

    }

}
