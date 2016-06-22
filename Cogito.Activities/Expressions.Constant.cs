using System;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Represents a constnat value used as an r-value, which supports binding of <see cref="ArgumentDirection.In"/> arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConstantValue<T> ConstantValue<T>(T value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            return new ConstantValue<T>(value);
        }

    }

}
