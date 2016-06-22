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
        /// Casts the parameters of type <typeparamref name="TOperand"/> to <typeparamref name="TResult"/>.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Cast<TOperand, TResult> Cast<TOperand, TResult>(DelegateInArgument<TOperand> operand, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(operand != null);

            return new Cast<TOperand, TResult>()
            {
                DisplayName = displayName,
                Operand = operand,
            };
        }

        /// <summary>
        /// Casts the parameters of type <typeparamref name="TOperand"/> to <typeparamref name="TResult"/>.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Cast<TOperand, TResult> Cast<TOperand, TResult>(Activity<TOperand> operand, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(operand != null);

            return new Cast<TOperand, TResult>()
            {
                DisplayName = displayName,
                Operand = operand,
            };
        }

    }

}
