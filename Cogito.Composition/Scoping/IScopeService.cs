using System;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Provides methods for interacting with scopes.
    /// </summary>
    public interface IScopeService
    {

        /// <summary>
        /// Resolves the <see cref="ITypeResolver"/> for the ambient scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        ITypeResolver Resolve(Type scopeType);

        /// <summary>
        /// Resolves the <see cref="ITypeResolver"/> for the ambient scope of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ITypeResolver Resolve<T>();

    }

}
