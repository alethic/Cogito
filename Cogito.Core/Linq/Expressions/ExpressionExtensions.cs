using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cogito.Linq.Expressions
{

    public static class ExpressionExtensions
    {
        /// <summary>
        /// Retrieves the member that an expression is defined for.
        /// </summary>
        /// <param name="self">The expression to retrieve the member from.</param>
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

        /// <summary>
        /// Navigates from the return value of the given <see cref="Expression"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="propertyPath"></param>
        /// <returns></returns>
        public static Expression GetPropertyOrFieldFromPath(this Expression self, string propertyPath)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (propertyPath == null)
                throw new ArgumentNullException(nameof(propertyPath));

            // split property path
            var path = propertyPath.Split('.')
                .Select(i => i.Trim())
                .ToArray();

            // recursively apply path to expression tree
            var expr = self;
            foreach (var i in path)
                expr = Expression.PropertyOrField(expr, i);

            return expr;
        }

        /// <summary>
        /// Navigates from the return value of the given <see cref="Expression"/> to the given property.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="self"></param>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public static Expression GetPropertyOrFieldExpression<TInput, TReturn>(this Expression self, Expression<Func<TInput, TReturn>> accessor)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (accessor == null)
                throw new ArgumentNullException(nameof(accessor));

            return self.GetPropertyOrFieldFromPath(accessor.GetPropertyOrFieldPath());
        }

        /// <summary>
        /// Applies an AndAlso operation between each <see cref="Expression"/> in the sequence.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Expression AndAlsoAll(this IEnumerable<Expression> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((i, j) => Expression.AndAlso(i, j));
        }

        /// <summary>
        /// Applies an OrElse operation between each <see cref="Expression"/> in the sequence.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Expression OrElseAll(this IEnumerable<Expression> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((i, j) => Expression.OrElse(i, j));
        }

    }

}
