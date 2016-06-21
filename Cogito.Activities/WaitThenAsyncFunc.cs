using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static WaitThenAsyncFunc<TWait, TResult> WaitThen<TWait, TResult>(InArgument<string> bookmarkName, Func<TWait, Task<TResult>> func)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new WaitThenAsyncFunc<TWait, TResult>(bookmarkName, func);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction"/>.
    /// </summary>
    public class WaitThenAsyncFunc<TWait, TResult> :
        NativeActivity<TResult>
    {

        readonly Variable<string> bookmarkName;
        readonly WaitForThen<TWait, TResult> wait;
        readonly AsyncFuncActivity<TWait, TResult> then;
        readonly DelegateInArgument<TWait> arg;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenAsyncFunc()
        {
            arg = new DelegateInArgument<TWait>();

            wait = new WaitForThen<TWait, TResult>(bookmarkName = new Variable<string>())
            {
                Then = new ActivityFunc<TWait, TResult>()
                {
                    Argument = arg,
                    Handler = then = new AsyncFuncActivity<TWait, TResult>()
                    {
                        Argument1 = arg,
                    },
                }
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThenAsyncFunc(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenAsyncFunc(InArgument<string> bookmarkName, Func<TWait, Task<TResult>> then)
            : this(bookmarkName)
        {
            Then = then;
        }

        /// <summary>
        /// Name of the bookmark to create.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        /// <summary>
        /// Action to be executed.
        /// </summary>
        [RequiredArgument]
        public Func<TWait, Task<TResult>> Then
        {
            get { return then.Func; }
            set { then.Func = value; }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(bookmarkName);
            metadata.AddImplementationChild(wait);
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait, OnWaitForThenComplete);
        }

        void OnWaitForThenComplete(NativeActivityContext context, ActivityInstance instance, TResult result)
        {
            context.SetValue(Result, result);
        }

    }

}
