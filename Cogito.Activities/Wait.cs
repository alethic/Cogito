using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static Wait Wait(InArgument<string> bookmarkName)
        {
            return new Wait(bookmarkName);
        }

        public static Wait<TResult> Wait<TResult>(InArgument<string> bookmarkName)
        {
            return new Wait<TResult>(bookmarkName);
        }

        public static Wait Wait<TWith>(Func<TWith, string> bookmarkName, InArgument<TWith> arg)
        {
            return new Wait(Func(bookmarkName, arg));
        }

        public static Wait Wait<TWith>(Func<TWith, string> bookmarkName, DelegateInArgument<TWith> arg)
        {
            return new Wait(Func(bookmarkName, arg));
        }

        public static Wait<TResult> Wait<TWith, TResult>(Func<TWith, string> bookmarkName, InArgument<TWith> arg)
        {
            return new Wait<TResult>(Func(bookmarkName, arg));
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed.
    /// </summary>
    public class Wait :
        NativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Wait()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public Wait(InArgument<string> bookmarkName)
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Name of the bookmark to create.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(context.GetValue(BookmarkName));
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class Wait<TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Wait()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public Wait(InArgument<string> bookmarkName)
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="result"></param>
        public Wait(InArgument<string> bookmarkName, OutArgument<TResult> result = null)
        {
            BookmarkName = bookmarkName;
            Result = result;
        }

        /// <summary>
        /// Name of the bookmark to create.
        /// </summary>
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(context.GetValue(BookmarkName), OnBookmarkCallback);
        }

        void OnBookmarkCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            context.SetValue(Result, (TResult)value);
        }

    }

}
