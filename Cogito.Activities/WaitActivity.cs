using System.Activities;

namespace Cogito.Activities
{

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed.
    /// </summary>
    public class WaitActivity :
        NativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitActivity(InArgument<string> bookmarkName)
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
    public class WaitActivity<TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitActivity(InArgument<string> bookmarkName)
        {
            BookmarkName = bookmarkName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="result"></param>
        public WaitActivity(InArgument<string> bookmarkName, OutArgument<TResult> result = null)
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
