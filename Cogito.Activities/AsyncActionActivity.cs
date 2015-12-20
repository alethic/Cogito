using System;
using System.Activities;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static AsyncActionActivity Action(Func<Task> func)
        {
            return new AsyncActionActivity(func);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncActionActivity :
        AsyncNativeActivity
    {

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action().BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

    }

}
