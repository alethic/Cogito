using System;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    /// <summary>
    /// Various extension methods for <see cref="TaskCompletionSource{TResult}"/> instances.
    /// </summary>
    public static class TaskCompletionSourceExtensions
    {

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the resulting
        /// <see cref="Task{TResult}"/>. Handles exceptions that might occur creating the <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static async Task<bool> SafeTrySetFromAsync<TResult>(this TaskCompletionSource<TResult> self, Func<Task<TResult>> func)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            try
            {
                return await SafeTrySetFromAsync(self, func());
            }
            catch (OperationCanceledException)
            {
                if (!self.TrySetCanceled())
                    return false;
            }
            catch (AggregateException e)
            {
                if (!self.TrySetException(e.InnerExceptions))
                    return false;
            }
            catch (Exception e)
            {
                if (!self.TrySetException(e))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the resulting
        /// <see cref="Task"/>. Handles exceptions that might occur creating the <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task<bool> SafeTrySetFromAsync<TResult>(this TaskCompletionSource<TResult> self, Func<Task> action)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return await SafeTrySetFromAsync(self, action());
            }
            catch (OperationCanceledException)
            {
                if (!self.TrySetCanceled())
                    return false;
            }
            catch (AggregateException e)
            {
                if (!self.TrySetException(e.InnerExceptions))
                    return false;
            }
            catch (Exception e)
            {
                if (!self.TrySetException(e))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the given
        /// <see cref="Task{TResult}"/>. Handles exceptions that might occur awaiting the <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        static async Task<bool> SafeTrySetFromAsync<TResult>(this TaskCompletionSource<TResult> self, Task<TResult> task)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            try
            {
                await task;
            }
            catch (Exception)
            {

            }

            return TrySetFrom(self, task);
        }

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the given
        /// <see cref="Task"/>. Handles exceptions that might occur awaiting the <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        static async Task<bool> SafeTrySetFromAsync<TResult>(this TaskCompletionSource<TResult> self, Task task)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            try
            {
                await task;
            }
            catch (Exception)
            {

            }

            return TrySetFrom(self, task);
        }

        /// <summary>
        /// Completes the given <see cref="TaskCompletionSource{TResult}"/> with the same results as the given <see cref="Task{TResult}"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="task"></param>
        public static bool TrySetFrom<TResult>(this TaskCompletionSource<TResult> self, Task<TResult> task)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (task == null)
                throw new ArgumentNullException(nameof(task));

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
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (task == null)
                throw new ArgumentNullException(nameof(task));

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
