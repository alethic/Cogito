using System;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;
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
        public static IAsyncResult BeginToAsync<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            Contract.Requires<ArgumentNullException>(task != null);
            
            var ec = ExecutionContext.Capture();
            var cs = new TaskCompletionSource<TResult>(state);

            task.ContinueWith(_ =>
            {
                if (_.IsFaulted)
                    cs.TrySetException(_.Exception.InnerExceptions);
                else if (_.IsCanceled)
                    cs.TrySetCanceled();
                else
                    cs.TrySetResult(_.Result);

                // invoke callback, which should invoke EndToAsync
                if (callback != null)
                    ExecutionContext.Run(ec, __ => callback((Task<TResult>)__), cs.Task);

            }, TaskContinuationOptions.ExecuteSynchronously);

            return cs.Task;
        }

        /// <summary>
        /// Implements the Begin method of the Asynchronous Programming Model pattern for a <see cref="Task"/>. 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static IAsyncResult BeginToAsync(this Task task, AsyncCallback callback, object state)
        {
            Contract.Requires<ArgumentNullException>(task != null);
            
            var ec = ExecutionContext.Capture();
            var cs = new TaskCompletionSource<object>(state);

            task.ContinueWith(_ =>
            {
                if (_.IsFaulted)
                    cs.TrySetException(_.Exception.InnerExceptions);
                else if (_.IsCanceled)
                    cs.TrySetCanceled();
                else
                    cs.TrySetResult(null);

                // invoke callback, which should invoke EndToAsync
                if (callback != null)
                    ExecutionContext.Run(ec, __ => callback((Task)__), cs.Task);

            }, TaskContinuationOptions.ExecuteSynchronously);

            return cs.Task;
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
                ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                throw e;
            }
        }

        /// <summary>
        /// Implements the End method of the Asynchronous Programming Model pattern for a <see cref="Task"/>. 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static void EndToAsync(this Task task)
        {
            Contract.Requires<ArgumentNullException>(task != null);

            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                throw e;
            }
        }

    }

}
