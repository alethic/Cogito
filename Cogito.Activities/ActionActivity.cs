using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        /// <summary>
        /// Creates an <see cref="Activity"/> to invoke the specified <see cref="Action{ActivityContext}"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ActionActivity Invoke(Action<ActivityContext> action)
        {
            return new ActionActivity(action);
        }

        /// <summary>
        /// Creates an <see cref="Activity"/> to invoke the specifed <see cref="Action"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ActionActivity Invoke(Action action)
        {
            return new ActionActivity(context => action());
        }

        /// <summary>
        /// Appends <paramref name="action"/> to be executed after the <see cref="Activity"/>.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Sequence Then(this Activity activity, Action action)
        {
            return Then(activity, new ActionActivity(context => action()));
        }

        /// <summary>
        /// Appends <paramref name="action"/> to be executed after the <see cref="Activity"/>.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Sequence Then(this Activity activity, Action<ActivityContext> action)
        {
            return Then(activity, new ActionActivity(action));
        }

        /// <summary>
        /// Appends <paramref name="action"/> to be executed after the <see cref="Activity"/>.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="activity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ActionActivity<TValue> Then<TValue>(this Activity<TValue> activity, Action<TValue> action)
        {
            return new ActionActivity<TValue>((arg, context) => action(arg), activity);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public partial class ActionActivity :
        NativeActivity
    {

        /// <summary>
        /// Converts a <see cref="ActionActivity"/> into an <see cref="ActivityAction"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction(ActionActivity activity)
        {
            return Activities.Delegate(() =>
            {
                return activity;
            });
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
        public ActionActivity(Action<ActivityContext> action)
            : this()
        {
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<ActivityContext> Action { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Action(context);
        }

    }

}
