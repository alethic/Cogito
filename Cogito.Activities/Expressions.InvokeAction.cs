using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction InvokeAction(ActivityAction action, string displayName = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new InvokeAction()
            {
                DisplayName = displayName,
                Action = action,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg> InvokeDelegate<TArg>(ActivityAction<TArg> action, InArgument<TArg> arg, string displayName = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new InvokeAction<TArg>()
            {
                DisplayName = displayName,
                Action = action,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg> InvokeDelegate<TArg>(ActivityAction<TArg> action, DelegateInArgument<TArg> arg, string displayName = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new InvokeAction<TArg>()
            {
                DisplayName = displayName,
                Action = action,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg> InvokeDelegate<TArg>(ActivityAction<TArg> action, Activity<TArg> arg, string displayName = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new InvokeAction<TArg>()
            {
                DisplayName = displayName,
                Action = action,
                Argument = arg,
            };
        }

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the action with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static InvokeAction<TArg> InvokeDelegate<TArg>(ActivityAction<TArg> action, Variable<TArg> arg, string displayName = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return new InvokeAction<TArg>()
            {
                DisplayName = displayName,
                Action = action,
                Argument = arg,
            };
        }

    }

}

