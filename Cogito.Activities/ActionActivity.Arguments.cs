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
        public static ActionActivity<TArg1> Invoke<TArg1>(Action<TArg1> action, InArgument<TArg1> arg1, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1>(action, arg1)
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
        public static ActionActivity<TArg1> Invoke<TArg1>(Action<TArg1> action, DelegateInArgument<TArg1> arg1, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1>(action, arg1)
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
        public static ActionActivity<TArg1> Invoke<TArg1>(Action<TArg1> action, Activity<TArg1> arg1, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1>(action, arg1)
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
        public static ActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Action<TArg1, TArg2> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2>(action, arg1, arg2)
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
        public static ActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Action<TArg1, TArg2> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2>(action, arg1, arg2)
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
        public static ActionActivity<TArg1, TArg2> Invoke<TArg1, TArg2>(Action<TArg1, TArg2> action, Activity<TArg1> arg1, Activity<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2>(action, arg1, arg2)
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
        public static ActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Action<TArg1, TArg2, TArg3> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3>(action, arg1, arg2, arg3)
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
        public static ActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Action<TArg1, TArg2, TArg3> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3>(action, arg1, arg2, arg3)
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
        public static ActionActivity<TArg1, TArg2, TArg3> Invoke<TArg1, TArg2, TArg3>(Action<TArg1, TArg2, TArg3> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3>(action, arg1, arg2, arg3)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Action<TArg1, TArg2, TArg3, TArg4> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4>(action, arg1, arg2, arg3, arg4)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Action<TArg1, TArg2, TArg3, TArg4> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4>(action, arg1, arg2, arg3, arg4)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4> Invoke<TArg1, TArg2, TArg3, TArg4>(Action<TArg1, TArg2, TArg3, TArg4> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4>(action, arg1, arg2, arg3, arg4)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(action, arg1, arg2, arg3, arg4, arg5)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(action, arg1, arg2, arg3, arg4, arg5)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5>(Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(action, arg1, arg2, arg3, arg4, arg5)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(action, arg1, arg2, arg3, arg4, arg5, arg6)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(action, arg1, arg2, arg3, arg4, arg5, arg6)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(action, arg1, arg2, arg3, arg4, arg5, arg6)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
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
        public static ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return new ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }


    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 1 arguments.
    /// </summary>
    public class ActionActivity<TArg1> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1}"/> to a <see cref="ActivityAction{TArg1}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1>(ActionActivity<TArg1> activity)
        {
            return Expressions.Delegate<TArg1>((arg1) =>
            {
                activity.Argument1 = arg1;
                return activity;
            });
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1> activity)
        {
            return Expressions.Delegate<TArg1>((arg1) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public ActionActivity(Action<TArg1> action = null, InArgument<TArg1> arg1 = null)
        {
            Action = action;
            Argument1 = arg1;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public ActionActivity(InArgument<TArg1> arg1 = null, Action<TArg1> action = null)
        {
            Argument1 = arg1;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            return executor(() => { Action(arg1); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 2 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2}"/> to a <see cref="ActivityAction{TArg1, TArg2}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2>(ActionActivity<TArg1, TArg2> activity)
        {
            return Expressions.Delegate<TArg1, TArg2>((arg1, arg2) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                return activity;
            });
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2> activity)
        {
            return Expressions.Delegate<TArg1, TArg2>((arg1, arg2) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public ActionActivity(Action<TArg1, TArg2> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, Action<TArg1, TArg2> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            return executor(() => { Action(arg1, arg2); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 3 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3>(ActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3>((arg1, arg2, arg3) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                return activity;
            });
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3>((arg1, arg2, arg3) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, Action<TArg1, TArg2, TArg3> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            return executor(() => { Action(arg1, arg2, arg3); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 4 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4>(ActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4>((arg1, arg2, arg3, arg4) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
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
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, Action<TArg1, TArg2, TArg3, TArg4> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            return executor(() => { Action(arg1, arg2, arg3, arg4); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 5 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5>((arg1, arg2, arg3, arg4, arg5) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
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
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
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
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, Action<TArg1, TArg2, TArg3, TArg4, TArg5> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            return executor(() => { Action(arg1, arg2, arg3, arg4, arg5); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 6 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((arg1, arg2, arg3, arg4, arg5, arg6) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
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
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
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
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            return executor(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 7 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
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
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
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
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action { get; set; }

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
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task>, Task> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            return executor(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7); return Task.FromResult(true); });
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 8 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
            {
                return activity;
            });
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
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
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Argument8 = arg8;
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
        public ActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action = null)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Argument8 = arg8;
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action { get; set; }

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

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
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
            return executor(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8); return Task.FromResult(true); });
        }

    }


}

