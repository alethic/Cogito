using System;
using System.Activities;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public class ActionActivity :
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
        public Action Action { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Action();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }

}
