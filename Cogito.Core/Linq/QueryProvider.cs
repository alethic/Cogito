using System;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Linq
{

    /// <summary>
    /// Abstract <see cref="IQueryProvider"/> implementation.
    /// </summary>
    public abstract class QueryProvider :
        IQueryProvider
    {

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var query = CreateQuery(typeof(TElement), this, expression) as IQueryable<TElement>;
            if (query == null)
                throw new NullReferenceException("Cannot create IQueryable.");

            return (IQueryable<TElement>)query;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var query = CreateQuery(expression.Type.GetElementType(), this, expression) as IQueryable;
            if (query == null)
                throw new NullReferenceException("Cannot create IQueryable.");

            return (IQueryable)query;
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            return (TResult)this.Execute(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return Execute(expression);
        }

        /// <summary>
        /// Creates a new <see cref="IQueryable"/> implementation for the given element type, expression and provider.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="provider"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual IQueryable CreateQuery(Type elementType, IQueryProvider provider, Expression expression)
        {
            return (IQueryable)Activator.CreateInstance(
                typeof(Query<>).MakeGenericType(elementType),
                provider,
                expression);
        }

        /// <summary>
        /// Implement this method to execute the given expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public abstract object Execute(Expression expression);

    }

}
