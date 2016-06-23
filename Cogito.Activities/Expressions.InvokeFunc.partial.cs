using System;
using System.Activities;
using System.Activities.Expressions;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TResult> InvokeFunc<TArg1, TArg2, TResult>(ActivityFunc<TArg1, TArg2, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            
            return new InvokeFunc<TArg1, TArg2, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TResult> InvokeFunc<TArg1, TArg2, TResult>(ActivityFunc<TArg1, TArg2, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            
            return new InvokeFunc<TArg1, TArg2, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TResult> InvokeFunc<TArg1, TArg2, TResult>(ActivityFunc<TArg1, TArg2, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            
            return new InvokeFunc<TArg1, TArg2, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TResult> InvokeFunc<TArg1, TArg2, TResult>(ActivityFunc<TArg1, TArg2, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            
            return new InvokeFunc<TArg1, TArg2, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TResult> InvokeFunc<TArg1, TArg2, TArg3, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TResult> InvokeFunc<TArg1, TArg2, TArg3, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TResult> InvokeFunc<TArg1, TArg2, TArg3, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TResult> InvokeFunc<TArg1, TArg2, TArg3, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, Variable<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            Contract.Requires<ArgumentNullException>(arg8 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            Contract.Requires<ArgumentNullException>(arg8 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            Contract.Requires<ArgumentNullException>(arg8 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Func = func,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the function with the specified arguments.
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
        /// <returns></returns>
        public static InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, Variable<TArg7> arg7, Variable<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);
            Contract.Requires<ArgumentNullException>(arg1 != null);
            Contract.Requires<ArgumentNullException>(arg2 != null);
            Contract.Requires<ArgumentNullException>(arg3 != null);
            Contract.Requires<ArgumentNullException>(arg4 != null);
            Contract.Requires<ArgumentNullException>(arg5 != null);
            Contract.Requires<ArgumentNullException>(arg6 != null);
            Contract.Requires<ArgumentNullException>(arg7 != null);
            Contract.Requires<ArgumentNullException>(arg8 != null);
            
            return new InvokeFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Func = func,
            };
        }

    }

}
