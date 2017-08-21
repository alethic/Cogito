using System;
using System.Activities;
using System.Activities.Expressions;
using System.Linq.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Represents a lambda expression used as an r-value, which supports binding of <see cref="ArgumentDirection.In"/> arguments.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="lambdaValue"></param>
        /// <returns></returns>
        public static LambdaValue<TResult> LambdaValue<TResult>(Expression<Func<ActivityContext, TResult>> lambdaValue)
        {
            if (lambdaValue == null)
                throw new ArgumentNullException(nameof(lambdaValue));

            return new LambdaValue<TResult>(lambdaValue);
        }

    }

}
