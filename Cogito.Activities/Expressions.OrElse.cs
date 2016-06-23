using System;
using System.Activities;
using System.Activities.Expressions;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Computes the logical OR of two values. To do this, both operands are evaluated to <see cref="Boolean"/>
        /// values. If both operands are <c>false</c> then the expression returns <c>false</c>. If one or both
        /// operands evaluate to <c>true</c>, the expression returns <c>true</c>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static OrElse OrElse(Activity<bool> left, Activity<bool> right, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(left != null);
            Contract.Requires<ArgumentNullException>(right != null);

            return new OrElse()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

    }

}
