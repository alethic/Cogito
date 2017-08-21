﻿using System;
using System.Activities;
using System.Activities.Expressions;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Casts the parameters of type <typeparamref name="TOperand"/> to <typeparamref name="TResult"/> or returns <c>null</c>.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static As<TOperand, TResult> As<TOperand, TResult>(DelegateInArgument<TOperand> operand, string displayName = null)
            where TOperand : TResult
        {
            if (operand == null)
                throw new ArgumentNullException(nameof(operand));

            return new As<TOperand, TResult>()
            {
                DisplayName = displayName,
                Operand = operand,
            };
        }

        /// <summary>
        /// Casts the parameters of type <typeparamref name="TOperand"/> to <typeparamref name="TResult"/> or returns <c>null</c>.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static As<TOperand, TResult> As<TOperand, TResult>(InArgument<TOperand> operand, string displayName = null)
            where TOperand : TResult
        {
            if (operand == null)
                throw new ArgumentNullException(nameof(operand));

            return new As<TOperand, TResult>()
            {
                DisplayName = displayName,
                Operand = operand,
            };
        }

        /// <summary>
        /// Casts the parameters of type <typeparamref name="TOperand"/> to <typeparamref name="TResult"/> or returns <c>null</c>.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="operand"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static As<TOperand, TResult> As<TOperand, TResult>(this Activity<TOperand> operand, string displayName = null)
            where TOperand : TResult
        {
            if (operand == null)
                throw new ArgumentNullException(nameof(operand));

            return new As<TOperand, TResult>()
            {
                DisplayName = displayName,
                Operand = operand,
            };
        }

    }

}
