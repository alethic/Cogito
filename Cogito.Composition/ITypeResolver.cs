using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides a simple service to resolve types from the container.
    /// </summary>
    [ContractClass(typeof(ITypeResolver_Contract))]
    public interface ITypeResolver
    {

        /// <summary>
        /// Resolves an instance of the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// Resolves a lazy instance of the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Lazy<T, IDictionary<string, object>> ResolveLazy<T>();

        /// <summary>
        /// Resolves all available instances of the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveMany<T>();

        /// <summary>
        /// Resolves all available lazy instances of the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<Lazy<T,IDictionary<string,object>>> ResolveManyLazy<T>();

        /// <summary>
        /// Resolves an instance of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves a lazy instance of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Lazy<object, IDictionary<string, object>> ResolveLazy(Type type);

        /// <summary>
        /// Resolves all available instances of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<object> ResolveMany(Type type);

        /// <summary>
        /// Resolves all available lazy instances of the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<Lazy<object, IDictionary<string, object>>> ResolveManyLazy(Type type);

    }

    [ContractClassFor(typeof(ITypeResolver))]
    class ITypeResolver_Contract :
        ITypeResolver
    {

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public Lazy<T, IDictionary<string, object>> ResolveLazy<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveMany<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, IDictionary<string, object>>> ResolveManyLazy<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            throw new NotImplementedException();
        }

        public Lazy<object, IDictionary<string, object>> ResolveLazy(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            throw new NotImplementedException();
        }

        public IEnumerable<object> ResolveMany(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<object, IDictionary<string, object>>> ResolveManyLazy(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            throw new NotImplementedException();
        }

    }

}
