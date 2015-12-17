using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Abstract base class for custom activities that implement execution logic using the 
    /// <see cref="BeginExecute(NativeActivityContext, AsyncCallback, object)"/> method, which has full access to
    /// the runtime's features.
    /// </summary>
    public abstract class AsyncNativeActivity :
        NativeActivity
    {

        /// <summary>
        /// For suspending persistance.
        /// </summary>
        Variable<NoPersistHandle> NoPersistHandle { get; set; }

        /// <summary>
        /// For resumption after async completion.
        /// </summary>
        Variable<Bookmark> Bookmark { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddImplementationVariable(NoPersistHandle = new Variable<NoPersistHandle>());
            metadata.AddImplementationVariable(Bookmark = new Variable<Bookmark>());
            metadata.AddDefaultExtensionProvider(() => new AsyncNativeActivityExtension());
            metadata.RequireExtension<AsyncNativeActivityExtension>();
        }

        /// <summary>
        /// Invoked to begin the activity execution.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected abstract IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state);

        /// <summary>
        /// Invoked to end the activity execution.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        protected abstract void EndExecute(NativeActivityContext context, IAsyncResult result);

        /// <summary>
        /// Runs the <see cref="Activity"/>s execution logic.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            // begin no persistence scope
            var noPersistHandle = NoPersistHandle.Get(context);
            noPersistHandle.Enter(context);

            // bookmark that will be resumed when execuction is complete
            var bookmark = context.CreateBookmark(BookmarkResumptionCallback);
            Bookmark.Set(context, bookmark);

            // extension to help us resume bookmarks
            var extension = context.GetExtension<AsyncNativeActivityExtension>();
            if (extension == null)
                throw new NullReferenceException();

            // begin user execution
            var result1 = BeginExecute(context, result2 =>
            {
                // result completed asychronously
                if (!result2.CompletedSynchronously)
                {
                    // upon completion, resume the bookmark
                    extension.Instance.BeginResumeBookmark(bookmark, result2, (result3) =>
                    {
                        // finish bookmark resume
                        extension.Instance.EndResumeBookmark(result3);
                    }, null);
                }
            }, null);

            // execution was finished immediately
            if (result1.CompletedSynchronously)
            {
                // exit no persistence sope
                noPersistHandle.Exit(context);

                // remove bookmark, never used
                context.RemoveBookmark(bookmark);

                // invoke user exeuction end
                EndExecute(context, result1);
            }
        }

        /// <summary>
        /// Invoked when the bookmark is resumed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        void BookmarkResumptionCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            // exit no persistence scope
            var noPersistHandle = NoPersistHandle.Get(context);
            noPersistHandle.Exit(context);

            // invoke user exeuction end
            EndExecute(context, value as IAsyncResult);
        }

    }

}
