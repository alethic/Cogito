using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace Cogito.Linq.Expressions
{

    public static class ExpressionExtensions
    {
        /// <summary>
        /// Retrieves the member that an expression is defined for.
        /// </summary>
        /// <param name="self">The expression to retreive the member from.</param>
        /// <returns>A <see cref="MemberInfo"/> instance if the member could be found; otherwise <see langword="null"/>.</returns>
        public static MemberInfo GetTargetMemberInfo(this Expression self)
        {
            Contract.Requires<ArgumentOutOfRangeException>(self != null);

            switch (self.NodeType)
            {
                case ExpressionType.Convert:
                    return GetTargetMemberInfo(((UnaryExpression)self).Operand);
                case ExpressionType.Lambda:
                    return GetTargetMemberInfo(((LambdaExpression)self).Body);
                case ExpressionType.Call:
                    return ((MethodCallExpression)self).Method;
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)self).Member;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets a dot-notation path for the given property or field expression.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string GetPropertyOrFieldPath<TInput, TResult>(this Expression<Func<TInput, TResult>> self)
        {
            Contract.Requires<ArgumentOutOfRangeException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.Body != null);

            var path = new LinkedList<string>();
            MemberExpression expr;

            // extract member expression from lambda
            switch (self.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = self.Body as UnaryExpression;
                    expr = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    break;
                default:
                    expr = self.Body as MemberExpression;
                    break;
            }

            // advance through members
            for (; expr != null; expr = expr.Expression as MemberExpression)
                path.AddFirst(expr.Member.Name);

            // join with separator
            return string.Join(".", path);
        }

    }

}
