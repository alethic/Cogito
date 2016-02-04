using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public static class TaskCompletionSourceExtensions
    {

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the given <see cref="Task{TResult}"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="task"></param>
        public static bool TrySetFrom<TResult>(this TaskCompletionSource<TResult> self, Task<TResult> task)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(task != null);

            if (task.IsFaulted)
            {
                if (!self.TrySetException(task.Exception.InnerExceptions))
                    return false;
            }
            else if (task.IsCanceled)
            {
                if (!self.TrySetCanceled())
                    return false;
            }
            else
            {
                if (!self.TrySetResult(task.Result))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the given <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="task"></param>
        public static bool TrySetFrom<TResult>(this TaskCompletionSource<TResult> self, Task task)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(task != null);

            if (task.IsFaulted)
            {
                if (!self.TrySetException(task.Exception.InnerExceptions))
                    return false;
            }
            else if (task.IsCanceled)
            {
                if (!self.TrySetCanceled())
                    return false;
            }
            else
            {
                if (!self.TrySetResult(default(TResult)))
                    return false;
            }

            return true;
        }

    }

}
