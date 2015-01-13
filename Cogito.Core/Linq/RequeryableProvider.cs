using System;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(expression != null);

            throw new NotImplementedException();
        }

    }

}
