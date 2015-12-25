using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static AsyncFuncActivity<TResult> Invoke<TResult>(Func<Task<TResult>> func)
        {
            return new AsyncFuncActivity<TResult>(context => func());
        }

        public static AsyncFuncActivity<TResult> InvokeWithContext<TResult>(Func<ActivityContext, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TResult>(func);
        }

        public static AsyncFuncActivity<TValue1, TValue2> Then<TValue1, TValue2>(this Activity<TValue1> activity, Func<TValue1, Task<TValue2>> func)
        {
            return new AsyncFuncActivity<TValue1, TValue2>((value, context) => func(value), activity);
        }

        public static AsyncFuncActivity<TValue1, TValue2> Then<TValue1, TValue2>(this Activity<TValue1> activity, Func<TValue1, ActivityContext, Task<TValue2>> func)
        {
            return new AsyncFuncActivity<TValue1, TValue2>(func, activity);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncFuncActivity<TResult> :
        AsyncTaskCodeActivity<TResult>
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
        public AsyncFuncActivity(Func<ActivityContext, Task<TResult>> func = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(OutArgument<TResult> result = null, Func<ActivityContext, Task<TResult>> func = null)
        {
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, Task<TResult>> Func { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context);
        }

    }

}
