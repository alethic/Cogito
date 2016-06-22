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

}
