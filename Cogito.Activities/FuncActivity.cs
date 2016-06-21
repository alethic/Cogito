using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static FuncActivity<TResult> Invoke<TResult>(Func<TResult> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TResult>(func);
        }

        public static FuncActivity<TSource, TResult> ThenWith<TSource, TResult>(this Activity<TSource> activity, Func<TSource, TResult> func)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TSource, TResult>(func, activity);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public class FuncActivity<TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TResult>(FuncActivity<TResult> activity)
        {
            return Activities.Delegate(() =>
            {
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        public FuncActivity(Func<TResult> func)
            : this()
        {
            Func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TResult> Func { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            return executor(() => Task.FromResult(Func()));
        }

    }

}
