using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static ActionActivity Action(Action<ActivityContext> action)
        {
            return new ActionActivity(action);
        }

        public static ActionActivity Action(Action action)
        {
            return new ActionActivity(context => action());
        }

        public static Sequence Then(this Activity activity, Action action)
        {
            return Then(activity, new ActionActivity(context => action()));
        }

        public static Sequence Then(this Activity activity, Action<ActivityContext> action)
        {
            return Then(activity, new ActionActivity(action));
        }

        public static ActionActivity<TValue> Then<TValue>(this Activity<TValue> activity, Action<TValue> action)
        {
            return new ActionActivity<TValue>((context, arg) => action(arg), activity);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public partial class ActionActivity :
        NativeActivity
    {

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
