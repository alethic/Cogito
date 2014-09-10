using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public static class TaskExtensions
    {

        /// <summary>
        /// Implements the Being method of the Asynchronous Programming Model pattern for a Task. 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Task<TResult> BeginToAsync<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            if (task.AsyncState == state)
            {
                if (callback != null)
                    task.ContinueWith(_ => callback(task), CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

                return task;
            }

            var tcs = new TaskCompletionSource<TResult>(state);

            task.ContinueWith(_ =>
            {
                if (task.IsFaulted)
                    tcs.TrySetException(task.Exception.InnerExceptions);
                else if (task.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(task.Result);

                if (callback != null)
                    callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

            return tcs.Task;
        }

        /// <summary>
        /// Implements the End method of the Asynchronous Programming Model pattern for a Task. 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public static TResult EndToAsync<TResult>(this Task<TResult> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException e) 
            {
                throw e.InnerException; 
            }
        }

    }

}
