using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static WaitThenAction<TWait> WaitThen<TWait>(InArgument<string> bookmarkName, Action<TWait> action)
        {
            return new WaitThenAction<TWait>(bookmarkName, (context, arg) => action(arg));
        }

        public static WaitThenAction<TWait> WaitThen<TWait>(InArgument<string> bookmarkName, Action<ActivityContext, TWait> action)
        {
            return new WaitThenAction<TWait>(bookmarkName, action);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction"/>.
    /// </summary>
    public class WaitThenAction :
        NativeActivity
    {

        readonly Variable<string> bookmarkName;
        readonly WaitThen wait;
        readonly ActionActivity then;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenAction()
        {
            wait = new WaitThen(bookmarkName = new Variable<string>())
            {
                Then = new ActivityAction()
                {
                    Handler = then = new ActionActivity(),
                }
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThenAction(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenAction(InArgument<string> bookmarkName, Action<ActivityContext> then)
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
        public Action<ActivityContext> Then
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
            metadata.AddImplementationChild(then);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction"/>.
    /// </summary>
    public class WaitThenAction<TWait> :
        NativeActivity
    {

        readonly Variable<string> bookmarkName;
        readonly WaitThen<TWait> wait;
        readonly ActionActivity<TWait> then;
        readonly DelegateInArgument<TWait> arg;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThenAction()
        {
            arg = new DelegateInArgument<TWait>();

            wait = new WaitThen<TWait>(bookmarkName = new Variable<string>())
            {
                Then = new ActivityAction<TWait>()
                {
                    Argument = arg,
                    Handler = then = new ActionActivity<TWait>()
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
        public WaitThenAction(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        public WaitThenAction(InArgument<string> bookmarkName, Action<ActivityContext, TWait> then)
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
        public Action<ActivityContext, TWait> Then
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
