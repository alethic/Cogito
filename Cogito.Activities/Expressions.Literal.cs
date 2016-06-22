using System.Activities;
using System.Activities.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity{TResult}"/> which returns the literal value.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Activity<T> Literal<T>(T value)
        {
            return new Literal<T>(value);
        }

    }

}
