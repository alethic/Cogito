using System;
using System.Activities;
using System.Threading;

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
            base.CacheMetadata(metadata);
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
            var ar = BeginExecute(context, ar2 =>
            {
                // bookmark removed below in sycnhronous pass
                if (ar2.CompletedSynchronously)
                    return;

                // resume bookmark
                extension.Instance.BeginResumeBookmark(bookmark, Tuple.Create(ar2, ExecutionContext.Capture()), ar3 =>
                {
                    ExecutionContext.Run((ExecutionContext)ar3.AsyncState, _ => extension.Instance.EndResumeBookmark(ar3), null);
                }, ExecutionContext.Capture());

            }, null);

            // execution was finished immediately
            if (ar.CompletedSynchronously)
            {
                // exit no persistence sope
                noPersistHandle.Exit(context);

                // remove bookmark, never used
                context.RemoveBookmark(bookmark);

                // invoke user exeuction end
                EndExecute(context, ar);
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
            var tuple = value as Tuple<IAsyncResult, ExecutionContext>;
            if (tuple != null)
            {
                ExecutionContext.Run(tuple.Item2, _ =>
                {
                    // exit no persistence scope
                    var noPersistHandle = NoPersistHandle.Get(context);
                    noPersistHandle.Exit(context);

                    // invoke user exeuction end
                    EndExecute(context, tuple.Item1);

                }, null);
            }
        }

    }

    /// <summary>
    /// Abstract base class for custom activities that implement execution logic using the 
    /// <see cref="BeginExecute(NativeActivityContext, AsyncCallback, object)"/> method, which has full access to
    /// the runtime's features.
    /// </summary>
    public abstract class AsyncNativeActivity<TResult> :
        NativeActivity<TResult>
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
            base.CacheMetadata(metadata);
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
        protected abstract TResult EndExecute(NativeActivityContext context, IAsyncResult result);

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
                Result.Set(context, EndExecute(context, result1));
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
            Result.Set(context, EndExecute(context, value as IAsyncResult));
        }

    }

}
