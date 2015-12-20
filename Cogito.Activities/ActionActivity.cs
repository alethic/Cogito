using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static ActionActivity Action(Action func)
        {
            return new ActionActivity(func);
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

        protected override void Execute(NativeActivityContext context)
        {
            Action();
        }

    }

}
