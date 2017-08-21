using System;
using System.Activities;
using System.Activities.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Computes the bitwise logic AND of two values.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"
        /// <typeparam name="TResult"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static And<TLeft, TRight, TResult> And<TLeft, TRight, TResult>(DelegateInArgument<TLeft> left, DelegateInArgument<TRight> right, string displayName = null)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new And<TLeft, TRight, TResult>()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

        /// <summary>
        /// Computes the bitwise logic AND of two values.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"
        /// <typeparam name="TResult"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static And<TLeft, TRight, TResult> And<TLeft, TRight, TResult>(InArgument<TLeft> left, InArgument<TRight> right, string displayName = null)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new And<TLeft, TRight, TResult>()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

        /// <summary>
        /// Computes the bitwise logic AND of two values.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"
        /// <typeparam name="TResult"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static And<TLeft, TRight, TResult> And<TLeft, TRight, TResult>(this Activity<TLeft> left, Activity<TRight> right, string displayName = null)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new And<TLeft, TRight, TResult>()
            {
                DisplayName = displayName,
                Left = left,
                Right = right,
            };
        }

    }

}
