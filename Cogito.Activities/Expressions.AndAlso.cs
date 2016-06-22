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
        /// Computes the logical AND of two values. Both values are converted into <see cref="Boolean"/>, and if both
        /// are <c>true</c> then this expression returns <c>true</c>. If one or both values evaluate to <c>false</c>,
        /// this expression returns <c>false</c>. <see cref="AndAlso"/> is the “short circuit” version of the logical
        /// AND operator, returning <c>false</c> as soon as one of operands is evaluated to be false.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static AndAlso AndAlso(Activity<bool> left, Activity<bool> right, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(left != null);
            Contract.Requires<ArgumentNullException>(right != null);

            return new AndAlso()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

    }

}
