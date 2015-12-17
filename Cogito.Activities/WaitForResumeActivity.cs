using System;
using System.Activities;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed.
    /// </summary>
    public class WaitForActivity :
        NativeActivity
    {

        /// <summary>
        /// Generates a new <see cref="WaitForActivity"/> with a random bookmark name.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static WaitForActivity Generate(out string bookmarkName)
        {
            return new WaitForActivity(bookmarkName = Guid.NewGuid().ToString());
        }

        readonly string bookmarkName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitForActivity(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(bookmarkName));

            this.bookmarkName = bookmarkName;
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(bookmarkName);
        }

    }

    /// <summary>
    /// Pauses execution until the given bookmark name is resumed.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class WaitForActivity<TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Generates a new <see cref="WaitForActivity"/> with a random bookmark name.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static WaitForActivity<TResult> Generate(out string bookmarkName)
        {
            return new WaitForActivity<TResult>(bookmarkName = Guid.NewGuid().ToString());
        }

        readonly string bookmarkName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitForActivity(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(bookmarkName));

            this.bookmarkName = bookmarkName;
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(bookmarkName, OnBookmarkCallback);
        }

        void OnBookmarkCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            context.SetValue(Result, (TResult)value);
        }

    }

}
