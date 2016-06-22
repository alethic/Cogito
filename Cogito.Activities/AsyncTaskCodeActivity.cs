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

        /// <summary>
        /// Allows the user to override the executor used to schedule tasks.
        /// </summary>
        public AsyncTaskExecutor Executor { get; set; }

        /// <summary>
        /// Initializes the activity metadata.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.RequireExtension<AsyncTaskExtension>();
            metadata.AddDefaultExtensionProvider(() => AsyncTaskExtension.Default);
        }

        /// <summary>
        /// Invoked to begin the task.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            return (ExecuteInternalAsync(context) ?? Task.FromResult(true)).ToAsyncBegin(callback, state);
        }

        /// <summary>
        /// Invoked when the task is ended.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
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
            // search local, for an executor scope, or default to the extension
            return ExecuteAsync(context,
                Executor ?? 
                context.GetProperty<AsyncTaskExecutorHandle>()?.Executor ?? 
                context.GetExtension<AsyncTaskExtension>().Executor);
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation. Ensure that you schedule any long term execution
        /// with the executor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected abstract Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor);

    }

    /// <summary>
    /// Provides a <see cref="AsyncCodeActivity"/> that handles <see cref="Task{TResult}"/>s.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class AsyncTaskCodeActivity<TResult> :
        AsyncCodeActivity<TResult>
    {

        /// <summary>
        /// Allows the user to override the executor used to schedule tasks.
        /// </summary>
        public AsyncTaskExecutor Executor { get; set; }

        /// <summary>
        /// Initializes the activity metadata.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.RequireExtension<AsyncTaskExtension>();
            metadata.AddDefaultExtensionProvider(() => AsyncTaskExtension.Default);
        }

        /// <summary>
        /// Invoked to begin the task.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            return (ExecuteInternalAsync(context) ?? Task.FromResult(default(TResult))).ToAsyncBegin(callback, state);
        }

        /// <summary>
        /// Invoked when the task is ended.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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
            // search local, for an executor scope, or default to the extension
            return ExecuteAsync(context,
                Executor ??
                context.GetProperty<AsyncTaskExecutorHandle>()?.Executor ??
                context.GetExtension<AsyncTaskExtension>().Executor);
        }

        /// <summary>
        /// Override this method to implement your asynchronous operation. Ensure that you schedule any long term execution
        /// with the executor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected abstract Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor);

    }

}
