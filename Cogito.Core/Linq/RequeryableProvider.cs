using System;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Core.Linq
{

    /// <summary>
    /// <see cref="IQueryProvider"/> who's queries can be applied to an underlying <see cref="IQueryable"/>.
    /// </summary>
    public class RequeryableProvider :
        QueryProvider
    {

        public override IQueryable CreateQuery(Type elementType, IQueryProvider provider, Expression expression)
        {
            return (IQueryable)Activator.CreateInstance(
                typeof(Requeryable<>).MakeGenericType(elementType),
                provider,
                expression);
        }

        public override object Execute(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            throw new NotImplementedException();
        }

    }

}
