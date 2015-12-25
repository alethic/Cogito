using System;
using System.Activities;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides a <see cref="AsyncCodeActivity"/> that handles <see cref="Task"/>s.
    /// </summary>
    public abstract class AsyncTaskCodeActivity :
        AsyncCodeActivity
    {

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.RequireExtension<AsyncActivityExtension>();
            metadata.AddDefaultExtensionProvider(() => new AsyncActivityExtension(null));
        }

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<bool>(state);

            using (new SynchronizationContextScope(context.GetExtension<AsyncActivityExtension>()?.SynchronizationContext ?? SynchronizationContext.Current))
            {
                (ExecuteAsync(context) ?? Task.FromResult(true))
                    .ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                            tcs.TrySetException(t.Exception.InnerExceptions);
                        else if (t.IsCanceled)
                            tcs.TrySetCanceled();
                        else
                            tcs.TrySetResult(true);

                        if (callback != null)
                            callback(tcs.Task);
                    }, TaskContinuationOptions.ExecuteSynchronously);
            }

            return tcs.Task;
        }

        protected sealed override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            try
            {
                ((Task)result).Wait();
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract Task ExecuteAsync(AsyncCodeActivityContext context);

    }

    /// <summary>
    /// Provides a <see cref="AsyncCodeActivity"/> that handles <see cref="Task{TResult}"/>s.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class AsyncTaskCodeActivity<TResult> :
        AsyncCodeActivity<TResult>
    {

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.RequireExtension<AsyncActivityExtension>();
            metadata.AddDefaultExtensionProvider(() => new AsyncActivityExtension(null));
        }

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<TResult>(state);

            using (new SynchronizationContextScope(context.GetExtension<AsyncActivityExtension>()?.SynchronizationContext ?? SynchronizationContext.Current))
            {
                (ExecuteAsync(context) ?? Task.FromResult(default(TResult)))
                    .ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                            tcs.TrySetException(t.Exception.InnerExceptions);
                        else if (t.IsCanceled)
                            tcs.TrySetCanceled();
                        else
                            tcs.TrySetResult(t.Result);

                        if (callback != null)
                            callback(tcs.Task);
                    }, TaskContinuationOptions.ExecuteSynchronously);
            }

            return tcs.Task;
        }

        protected sealed override TResult EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            try
            {
                return ((Task<TResult>)result).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract Task<TResult> ExecuteAsync(AsyncCodeActivityContext context);

    }

}
