using System;
using System.Linq.Expressions;

namespace Cogito.Linq.Expressions
{

    /// <summary>
    /// Removes unneccessary Convert operations from a <see cref="Expression"/>.
    /// </summary>
    public class RedundantConvertExpressionTransformer :
         ExpressionVisitor
    {

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert &&
                node.Type.GetGenericTypeDefinition() != typeof(Nullable<>) &&
                node.Type.IsAssignableFrom(node.Operand.Type))
                return base.Visit(node.Operand);

            return base.VisitUnary(node);
        }

    }

}
