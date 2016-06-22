using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1> Invoke<TArg1>(Func<TArg1, Task> func, InArgument<TArg1> arg1, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1>(func, arg1)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1> Invoke<TArg1>(Func<TArg1, Task> func, DelegateInArgument<TArg1> arg1, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1>(func, arg1)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1> Invoke<TArg1>(Func<TArg1, Task> func, Activity<TArg1> arg1, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1>(func, arg1)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
/// <typeparam name="TArg8"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
/// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
/// <typeparam name="TArg8"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
/// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="action"/> with arguments.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
/// <typeparam name="TArg8"></typeparam>
        /// <param name="action"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
/// <param name="arg8"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 1 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1>(AsyncActionActivity<TArg1> activity)
        {
            return Expressions.Delegate<TArg1>((arg1) =>
            {
                activity.Argument1 = arg1;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(Func<TArg1, Task> action = null, InArgument<TArg1> arg1 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, Func<TArg1, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            return executor(() => Action(arg1));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 2 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2>(AsyncActionActivity<TArg1, TArg2> activity)
        {
            return Expressions.Delegate<TArg1, TArg2>((arg1, arg2) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, Func<TArg1, TArg2, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            return executor(() => Action(arg1, arg2));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 3 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3>(AsyncActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3>((arg1, arg2, arg3) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, Func<TArg1, TArg2, TArg3, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            return executor(() => Action(arg1, arg2, arg3));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 4 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4>(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4>((arg1, arg2, arg3, arg4) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, Func<TArg1, TArg2, TArg3, TArg4, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            return executor(() => Action(arg1, arg2, arg3, arg4));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 5 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5>(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5>((arg1, arg2, arg3, arg4, arg5) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            return executor(() => Action(arg1, arg2, arg3, arg4, arg5));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 6 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((arg1, arg2, arg3, arg4, arg5, arg6) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            return executor(() => Action(arg1, arg2, arg3, arg4, arg5, arg6));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 7 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                activity.Argument7 = arg7;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            return executor(() => Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 8 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncTaskCodeActivity
    {

        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                activity.Argument7 = arg7;
                activity.Argument8 = arg8;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Argument8 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            var arg8 = Argument8.Get(context);
            return executor(() => Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        }

    }


}

