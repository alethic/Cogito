using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static WaitThenAsyncAction WaitThen(InArgument<string> bookmarkName, Func<ActivityContext, Task> action)
        {
            return new WaitThenAsyncAction(bookmarkName, action);
        }

        public static WaitThenAsyncAction WaitThen(InArgument<string> bookmarkName, Func<Task> action)
        {
            return new WaitThenAsyncAction(bookmarkName, context => action());
        }

        public static WaitThenAsyncAction<TWait> WaitThen<TWait>(InArgument<string> bookmarkName, Func<TWait, ActivityContext, Task> action)
        {
            return new WaitThenAsyncAction<TWait>(bookmarkName, action);
        }

        public static WaitThenAsyncAction<TWait> WaitThen<TWait>(InArgument<string> bookmarkName, Func<TWait, Task> action)
        {
            return new WaitThenAsyncAction<TWait>(bookmarkName, (arg, context) => action(arg));
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's asynchronous action.
    /// </summary>
    public class WaitThenAsyncAction :
        NativeActivity
    {

        readonly Variable<string> bookmarkName;
        readonly WaitThen wait;
        readonly AsyncActionActivity then;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenAsyncAction()
        {
            wait = new WaitThen(bookmarkName = new Variable<string>())
            {
                Then = new ActivityAction()
                {
                    Handler = then = new AsyncActionActivity(),
                }
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThenAsyncAction(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenAsyncAction(InArgument<string> bookmarkName, Func<ActivityContext, Task> then)
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
        public Func<ActivityContext, Task> Then
        {
            get { return then.Action; }
            set { then.Action = value; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(bookmarkName);
            metadata.AddImplementationChild(wait);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's asynchronous action.
    /// </summary>
    public class WaitThenAsyncAction<TWait> :
        NativeActivity
    {

        readonly Variable<string> bookmarkName;
        readonly WaitThen<TWait> wait;
        readonly AsyncActionActivity<TWait> then;
        readonly DelegateInArgument<TWait> arg1;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenAsyncAction()
        {
            arg1 = new DelegateInArgument<TWait>();

            wait = new WaitThen<TWait>(bookmarkName = new Variable<string>())
            {
                Then = new ActivityAction<TWait>()
                {
                    Argument = arg1,
                    Handler = then = new AsyncActionActivity<TWait>()
                    {
                        Argument1 = arg1,
                    },
                }
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThenAsyncAction(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenAsyncAction(InArgument<string> bookmarkName, Func<TWait, ActivityContext, Task> then)
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
        public Func<TWait, ActivityContext, Task> Then
        {
            get { return then.Action; }
            set { then.Action = value; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(bookmarkName);
            metadata.AddImplementationChild(wait);
        }

    }

}
