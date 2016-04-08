using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        /// <summary>
        /// Creates a new <see cref="Assign"/>.
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
        /// Creates a new <see cref="Assign"/>.
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

    }

}
