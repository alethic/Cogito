using System;
using System.Activities;
using System.Activities.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Performs a relational test between two values. If the left operand is less than or equal to the right operand, the expression returns true. Otherwise, it returns false.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static LessThanOrEqual<TLeft, TRight, TResult> LessThanOrEqual<TLeft, TRight, TResult>(InArgument<TLeft> left, InArgument<TRight> right, string displayName = null)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new LessThanOrEqual<TLeft, TRight, TResult>()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

    }

}
