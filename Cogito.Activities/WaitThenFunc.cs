using System;
using System.Activities;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TWaitFor"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static WaitThenFunc<TWaitFor, TResult> WaitThen<TWaitFor, TResult>(InArgument<string> bookmarkName, Func<TWaitFor, TResult> func)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new WaitThenFunc<TWaitFor, TResult>(bookmarkName, func);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction"/>.
    /// </summary>
    public class WaitThenFunc<TWaitFor, TResult> :
        NativeActivity<TResult>
    {

        readonly Variable<string> bookmarkName;
        readonly WaitForThen<TWaitFor, TResult> wait;
        readonly FuncActivity<TWaitFor, TResult> then;
        readonly DelegateInArgument<TWaitFor> arg;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenFunc()
        {
            arg = new DelegateInArgument<TWaitFor>();

            wait = new WaitForThen<TWaitFor, TResult>(bookmarkName = new Variable<string>())
            {
                Then = new ActivityFunc<TWaitFor, TResult>()
                {
                    Argument = arg,
                    Handler = then = new FuncActivity<TWaitFor, TResult>()
                    {
                        Argument1 = arg,
                    },
                },
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThenFunc(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenFunc(InArgument<string> bookmarkName, Func<TWaitFor, TResult> then)
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
        public Func<TWaitFor, TResult> Then
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
