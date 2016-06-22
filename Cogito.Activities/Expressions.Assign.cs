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
        /// <returns></returns>
        public static Assign Assign(this InArgument value, OutArgument to)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign()
            {
                Value = value,
                To = to,
            };
        }

        /// <summary>
        /// Assigns <paramref name="value"/> to <paramref name="to"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Assign<T> Assign<T>(this InArgument<T> value, OutArgument<T> to)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return new Assign<T>()
            {
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
        /// <returns></returns>
        public static Assign<T> Assign<T>(this Activity<T> value, OutArgument<T> to)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(to != null);

            return Assign((InArgument<T>)value, to);
        }

    }

}
