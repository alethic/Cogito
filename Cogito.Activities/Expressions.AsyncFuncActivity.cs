using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, InArgument<TArg1> arg1, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return new AsyncFuncActivity<TArg1, TResult>(func, arg1)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, DelegateInArgument<TArg1> arg1, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return new AsyncFuncActivity<TArg1, TResult>(func, arg1)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, Activity<TArg1> arg1, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return new AsyncFuncActivity<TArg1, TResult>(func, arg1)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <typeparam name="TArg8"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <typeparam name="TArg8"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }
        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/> with arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <typeparam name="TArg4"></typeparam>
        /// <typeparam name="TArg5"></typeparam>
        /// <typeparam name="TArg6"></typeparam>
        /// <typeparam name="TArg7"></typeparam>
        /// <typeparam name="TArg8"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, string displayName = null, AsyncTaskExecutor executor = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
                Executor = executor,
            };
        }

    }

}
