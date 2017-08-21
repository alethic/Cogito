using System;
using System.Activities;
using System.Activities.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TResult> InvokeFunc<TResult>(ActivityFunc<TResult> func, string displayName = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return new InvokeFunc<TResult>()
            {
                DisplayName = displayName,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg, TResult> InvokeFunc<TArg, TResult>(ActivityFunc<TArg, TResult> func, InArgument<TArg> arg, string displayName = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return new InvokeFunc<TArg, TResult>()
            {
                DisplayName = displayName,
                Func = func,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg, TResult> InvokeFunc<TArg, TResult>(ActivityFunc<TArg, TResult> func, DelegateInArgument<TArg> arg, string displayName = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return new InvokeFunc<TArg, TResult>()
            {
                DisplayName = displayName,
                Func = func,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg, TResult> InvokeFunc<TArg, TResult>(ActivityFunc<TArg, TResult> func, Activity<TArg> arg, string displayName = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return new InvokeFunc<TArg, TResult>()
            {
                DisplayName = displayName,
                Func = func,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg, TResult> InvokeFunc<TArg, TResult>(ActivityFunc<TArg, TResult> func, Variable<TArg> arg, string displayName = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return new InvokeFunc<TArg, TResult>()
            {
                DisplayName = displayName,
                Func = func,
                Argument = arg,
            };
        }

    }

}

