using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(InArgument<T> value, OutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(InArgument<T> value, DelegateOutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(InArgument<T> value, Variable<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateInArgument<T> value, OutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateInArgument<T> value, DelegateOutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateInArgument<T> value, Variable<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Activity<T> value, OutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Activity<T> value, DelegateOutArgument<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Activity<T> value, Variable<T> to, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                Value = value,
                To = to,
            };
        }

    }

}
