using System;
using System.Activities;

namespace Cogito.Activities
{


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
        public Func<TResult> Func { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func());
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }

}
