using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Collections;
using Cogito.Composition.Hosting;
using Cogito.Linq;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Implements a <see cref="ComposablePartCatalog"/> that exposes parts from the given parent <see
    /// cref="ComposablePartCatalog"/> that are within one of the supported scopes.
    /// </summary>
    public class ScopeCatalog :
        ComposablePartCatalog
    {

        readonly ComposablePartCatalog parent;
        readonly HashSet<Type> scopes;
        readonly IEnumerable<ComposablePartDefinition> parts;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public ScopeCatalog(ComposablePartCatalog parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            this.parent = parent;
            this.scopes = new HashSet<Type>();
            this.parts = parent.Parts.Where(i => Filter(i)).Tee(true);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="scopeType"></param>
        public ScopeCatalog(ComposablePartCatalog parent, Type scopeType)
            : this(parent)
        {
            // include specified scope
            if (scopeType != null)
                foreach (var i in GetScopeTypes(scopeType))
                    scopes.Add(i);
        }

        public override IEnumerator<ComposablePartDefinition> GetEnumerator()
        {
            return parts.GetEnumerator();
        }

        /// <summary>
        /// Expands the given scope <see cref="Type"/> into the set of all supported types.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        IEnumerable<Type> GetScopeTypes(Type scope)
        {
            Contract.Requires<ArgumentNullException>(scope != null);

            // add all base types
            foreach (var i in scope.Recurse(i => i.BaseType))
                yield return i;

            // add all supported interfaces
            foreach (var i in scope.GetInterfaces())
                yield return i;
        }

        /// <summary>
        /// Returns <c>true</c> if the given <see cref="ScopePartDefinition"/> declares the part to be available in
        /// any of the catalog's scopes.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        protected bool Filter(ComposablePartDefinition definition)
        {
            Contract.Requires<ArgumentNullException>(definition != null);

            // if limited to scopes, filter by scope; else only return objects with no scope
            var l = GetScopes(definition).ToList();
            return
                l.Any() == false && scopes.Count == 0 || // part is only available to root scope, and this is an unscoped catalog
                l.Contains(typeof(IEveryScope)) || // part is available to all scopes
                l.Any(i => scopes.Contains(i)); // part is only available to specified scopes;
        }

        /// <summary>
        /// Extracts the scope attributes from the given definition.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        IEnumerable<Type> GetScopes(ComposablePartDefinition definition)
        {
            var o = definition.Metadata.GetOrDefault(CompositionConstants.ScopeMetadataKey);

            if (o is IEnumerable<Type>)
                return (IEnumerable<Type>)o;

            if (o is Type)
                return new[] { (Type)o };

            return Enumerable.Empty<Type>();
        }

    }

}
