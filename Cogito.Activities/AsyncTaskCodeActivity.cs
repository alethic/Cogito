using System;
using System.Activities;
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
            metadata.RequireExtension<AsyncTaskExtension>();
            metadata.AddDefaultExtensionProvider(() => AsyncTaskExtension.Default);
        }

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            return (ExecuteInternalAsync(context) ?? Task.FromResult(true)).ToAsyncBegin(callback, state);
        }

        protected sealed override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            ((Task)result).ToAsyncEnd();
        }

        /// <summary>
        /// Executes the user code to retrieve the task.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ExecuteInternalAsync(AsyncCodeActivityContext context)
        {
            return ExecuteAsync(context, context.GetExtension<AsyncTaskExtension>().ExecuteAsync);
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation. Ensure that you schedule any long term execution
        /// with the executor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected abstract Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor);

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
            metadata.RequireExtension<AsyncTaskExtension>();
            metadata.AddDefaultExtensionProvider(() => AsyncTaskExtension.Default);
        }

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            return (ExecuteInternalAsync(context) ?? Task.FromResult(default(TResult))).ToAsyncBegin(callback, state);
        }

        protected sealed override TResult EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).ToAsyncEnd();
        }

        /// <summary>
        /// Executes the user code to retrieve the task.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<TResult> ExecuteInternalAsync(AsyncCodeActivityContext context)
        {
            return ExecuteAsync(context, context.GetExtension<AsyncTaskExtension>().ExecuteAsync);
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation. Ensure that you schedule any long term execution
        /// with the executor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected abstract Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor);

    }

}
