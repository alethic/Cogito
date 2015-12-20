using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static WaitThenFunc<TWaitFor, TResult> WaitThen<TWaitFor, TResult>(InArgument<string> bookmarkName, Func<ActivityContext, TWaitFor, TResult> action)
        {
            return new WaitThenFunc<TWaitFor, TResult>(bookmarkName, action);
        }

        public static WaitThenFunc<TWaitFor, TResult> WaitThen<TWaitFor, TResult>(InArgument<string> bookmarkName, Func<TWaitFor, TResult> action)
        {
            return new WaitThenFunc<TWaitFor, TResult>(bookmarkName, (context, arg) => action(arg));
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
        public WaitThenFunc(InArgument<string> bookmarkName, Func<ActivityContext, TWaitFor, TResult> then)
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
        public Func<ActivityContext, TWaitFor, TResult> Then
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
