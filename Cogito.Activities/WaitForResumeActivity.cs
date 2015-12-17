using System;
using System.Activities;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    /// <summary>
    /// Pauses exeuction until the given bookmark name is resumed.
    /// </summary>
    public class WaitForResumeActivity :
        NativeActivity
    {

        /// <summary>
        /// Generates a new <see cref="WaitForResumeActivity"/> with a random bookmark name.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static WaitForResumeActivity Generate(out string bookmarkName)
        {
            return new WaitForResumeActivity(bookmarkName = Guid.NewGuid().ToString());
        }

        readonly string bookmarkName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bookmarkName"></param>
        public WaitForResumeActivity(string bookmarkName)
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

}
