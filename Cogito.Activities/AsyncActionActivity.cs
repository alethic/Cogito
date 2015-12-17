using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncActionActivity :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }

}
