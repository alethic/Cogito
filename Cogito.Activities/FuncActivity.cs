using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        public static FuncActivity<TResult> Invoke<TResult>(Func<TResult> func, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TResult>(func)
            {
                DisplayName = displayName
            };
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
            return Expressions.Delegate(() =>
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
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            return Func != null ? executor.ExecuteAsync(() => Task.FromResult(Func())) : null;
        }

    }

}
