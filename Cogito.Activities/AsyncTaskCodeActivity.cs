using System;
using System.Activities;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public abstract class AsyncTaskCodeActivity :
        AsyncCodeActivity
    {

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<bool>(state);

            ExecuteAsync(context).ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(true);

                if (callback != null)
                    callback(tcs.Task);
            });

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

        protected abstract Task ExecuteAsync(AsyncCodeActivityContext context);

    }

    public abstract class AsyncTaskCodeActivity<TResult> :
        AsyncCodeActivity<TResult>
    {

        protected sealed override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<TResult>(state);

            ExecuteAsync(context).ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(t.Result);

                if (callback != null)
                    callback(tcs.Task);
            });

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

        protected abstract Task<TResult> ExecuteAsync(AsyncCodeActivityContext context);

    }

}
