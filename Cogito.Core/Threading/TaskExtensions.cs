using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    /// <summary>
    /// Provides some extension methods for <see cref="Task"/> objects.
    /// </summary>
    public static class TaskExtensions
    {

        /// <summary>
        /// Implements the Begin method of the Asynchronous Programming Model pattern for a <see cref="Task"/>. 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Task<TResult> BeginToAsync<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            Contract.Requires<ArgumentNullException>(task != null);

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
        /// Implements the End method of the Asynchronous Programming Model pattern for a <see cref="Task"/>. 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static TResult EndToAsync<TResult>(this Task<TResult> task)
        {
            Contract.Requires<ArgumentNullException>(task != null);

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
