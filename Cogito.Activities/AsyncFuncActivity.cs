using System;
using System.Activities;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static AsyncFuncActivity<TResult> Func<TResult>(Func<Task<TResult>> func)
        {
            return new AsyncFuncActivity<TResult>(func);
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncFuncActivity<TResult> :
        AsyncNativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<Task<TResult>> func = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(OutArgument<TResult> result = null, Func<Task<TResult>> func = null)
        {
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<Task<TResult>> Func { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Func().BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

    }

}
