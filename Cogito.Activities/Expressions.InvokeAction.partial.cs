using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg1, TArg2> InvokeAction<TArg1, TArg2>(ActivityAction<TArg1, TArg2> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg1, TArg2> InvokeAction<TArg1, TArg2>(ActivityAction<TArg1, TArg2> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg1, TArg2> InvokeAction<TArg1, TArg2>(ActivityAction<TArg1, TArg2> action, Activity<TArg1> arg1, Activity<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg1"></typeparam>
        /// <typeparam name="TArg2"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg1, TArg2> InvokeAction<TArg1, TArg2>(ActivityAction<TArg1, TArg2> action, Variable<TArg1> arg1, Variable<TArg2> arg2, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3> InvokeAction<TArg1, TArg2, TArg3>(ActivityAction<TArg1, TArg2, TArg3> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3> InvokeAction<TArg1, TArg2, TArg3>(ActivityAction<TArg1, TArg2, TArg3> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3> InvokeAction<TArg1, TArg2, TArg3>(ActivityAction<TArg1, TArg2, TArg3> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3> InvokeAction<TArg1, TArg2, TArg3>(ActivityAction<TArg1, TArg2, TArg3> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4> InvokeAction<TArg1, TArg2, TArg3, TArg4>(ActivityAction<TArg1, TArg2, TArg3, TArg4> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4> InvokeAction<TArg1, TArg2, TArg3, TArg4>(ActivityAction<TArg1, TArg2, TArg3, TArg4> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4> InvokeAction<TArg1, TArg2, TArg3, TArg4>(ActivityAction<TArg1, TArg2, TArg3, TArg4> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4> InvokeAction<TArg1, TArg2, TArg3, TArg4>(ActivityAction<TArg1, TArg2, TArg3, TArg4> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, Variable<TArg7> arg7, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
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
        public static InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action, Variable<TArg1> arg1, Variable<TArg2> arg2, Variable<TArg3> arg3, Variable<TArg4> arg4, Variable<TArg5> arg5, Variable<TArg6> arg6, Variable<TArg7> arg7, Variable<TArg8> arg8, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            
            return new InvokeAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
            {
                Argument1 = arg1,
                Argument2 = arg2,
                Argument3 = arg3,
                Argument4 = arg4,
                Argument5 = arg5,
                Argument6 = arg6,
                Argument7 = arg7,
                Argument8 = arg8,
                Action = action,
            };
        }

    }

}
