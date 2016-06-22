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
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(OutArgument<T> to, InArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(OutArgument<T> to, DelegateInArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(OutArgument<T> to, Activity<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateOutArgument<T> to, InArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateOutArgument<T> to, DelegateInArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(DelegateOutArgument<T> to, Activity<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Variable<T> to, InArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Variable<T> to, DelegateInArgument<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Variable<T> to, Activity<T> value, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(to != null);
            Contract.Requires<ArgumentNullException>(value != null);

            return new Assign<T>()
            {
                DisplayName = displayName,
                To = to,
                Value = value,
            };
        }

    }

}
