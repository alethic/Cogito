using System;
using System.Collections.Generic;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Resolves types within scopes.
    /// </summary>
    public interface IScopeTypeResolver
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="scopeType"></param>
        object Resolve(Type objectType, Type scopeType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        T Resolve<T>(Type scopeType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        T Resolve<T, TScope>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        IEnumerable<object> ResolveMany(Type objectType, Type scopeType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        IEnumerable<T> ResolveMany<T>(Type scopeType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveMany<T, TScope>();

    }

}
