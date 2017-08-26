using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cogito.Linq.Expressions
{

    /// <summary>
    /// Removes unnecessary Convert operations from a <see cref="Expression"/>.
    /// </summary>
    public class RedundantConvertExpressionTransformer :
         ExpressionVisitor
    {

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert &&
                node.Type.GetGenericTypeDefinition() != typeof(Nullable<>) &&
                node.Type.GetTypeInfo().IsAssignableFrom(node.Operand.Type))
                return base.Visit(node.Operand);

            return base.VisitUnary(node);
        }

    }

}
