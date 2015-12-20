using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class FuncActivity
    {

        public static FuncActivity<TResult> Create<TResult>(Func<TResult> func)
        {
            return new FuncActivity<TResult>(func);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function.
    /// </summary>
    public class FuncActivity<TResult> :
        NativeActivity<TResult>
    {

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func());
        }

    }

}
