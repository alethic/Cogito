using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Waits for a bookmark with the given name before continuing.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        public static Wait Wait(InArgument<string> bookmarkName)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));

            return new Wait(bookmarkName);
        }

        /// <summary>
        /// Waits for a bookmark with the given name before continuing.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        public static Wait<TResult> Wait<TResult>(InArgument<string> bookmarkName)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));

            return new Wait<TResult>(bookmarkName);
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
