using System;
using System.Activities;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        /// <summary>
        /// Waits for the given bookmark, and then executes the <paramref name="then"/> <see cref="ActivityAction"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        /// <returns></returns>
        public static WaitThen WaitThen(InArgument<string> bookmarkName, ActivityAction then)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return new WaitThen(bookmarkName, then);
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes the <paramref name="then"/> <see cref="Activity"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        /// <returns></returns>
        public static WaitThen WaitThen(InArgument<string> bookmarkName, Activity then)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return new WaitThen(bookmarkName, new ActivityAction()
            {
                Handler = then,
            });
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes the <paramref name="then"/> <see cref="ActivityAction{TWait}"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        /// <returns></returns>
        public static WaitThen<TWait> WaitThen<TWait>(InArgument<string> bookmarkName, ActivityAction<TWait> then)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return new WaitThen<TWait>(bookmarkName, then);
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes the <paramref name="then"/> <see cref="ActivityFunc{TWait, TResult}"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="then"></param>
        /// <returns></returns>
        public static WaitForThen<TWait, TResult> WaitThen<TWait, TResult>(InArgument<string> bookmarkName, ActivityFunc<TWait, TResult> then)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return new WaitForThen<TWait, TResult>(bookmarkName, then);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction"/>.
    /// </summary>
    public class WaitThen :
        NativeActivity
    {

        readonly Variable<string> bookmarkName;
        readonly Wait wait;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThen()
        {
            wait = new Wait(bookmarkName = new Variable<string>());
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThen(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThen(InArgument<string> bookmarkName, ActivityAction then)
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
        /// Activity to be scheduled after the wait.
        /// </summary>
        [RequiredArgument]
        public ActivityAction Then { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait, WaitCompleted);
        }

        void WaitCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Contract.Requires<ArgumentNullException>(completedInstance != null);

            context.ScheduleAction(Then);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationChild(wait);
            metadata.AddImplementationVariable(bookmarkName);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction{TValue}"/>.
    /// </summary>
    public class WaitThen<TWait> :
        NativeActivity<TWait>
    {

        readonly Wait<TWait> wait;
        readonly Variable<string> bookmarkName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitThen()
        {
            wait = new Wait<TWait>(bookmarkName = new Variable<string>());
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThen(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitThen(InArgument<string> bookmarkName, ActivityAction<TWait> then)
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
        /// Activity to be scheduled after the wait.
        /// </summary>
        [RequiredArgument]
        public ActivityAction<TWait> Then { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait, WaitCompleted);
        }

        void WaitCompleted(NativeActivityContext context, ActivityInstance completedInstance, TWait value)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Contract.Requires<ArgumentNullException>(completedInstance != null);

            context.ScheduleAction(Then, value);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(bookmarkName);
            metadata.AddImplementationChild(wait);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed, and then executes it's <see cref="ActivityAction{TValue}"/>.
    /// </summary>
    public class WaitForThen<TWaitFor, TResult> :
        NativeActivity<TResult>
    {

        readonly Wait<TWaitFor> wait;
        readonly Variable<string> bookmarkName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WaitForThen()
        {
            wait = new Wait<TWaitFor>(bookmarkName = new Variable<string>());
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitForThen(InArgument<string> bookmarkName)
            : this()
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitForThen(InArgument<string> bookmarkName, ActivityFunc<TWaitFor, TResult> then)
            : this(bookmarkName)
        {
            BookmarkName = bookmarkName;
            Then = then;
        }

        /// <summary>
        /// Name of the bookmark to create.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        /// <summary>
        /// Activity to be scheduled after the wait.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<TWaitFor, TResult> Then { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(bookmarkName, context.GetValue(BookmarkName));
            context.ScheduleActivity(wait, WaitCompleted);
        }

        void WaitCompleted(NativeActivityContext context, ActivityInstance completedInstance, TWaitFor value)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Contract.Requires<ArgumentNullException>(completedInstance != null);

            context.ScheduleFunc(Then, value, ThenCompleted);
        }

        void ThenCompleted(NativeActivityContext context, ActivityInstance completedInstance, TResult result)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Contract.Requires<ArgumentNullException>(completedInstance != null);

            context.SetValue(Result, result);
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(bookmarkName);
            metadata.AddImplementationChild(wait);
        }

    }

}
