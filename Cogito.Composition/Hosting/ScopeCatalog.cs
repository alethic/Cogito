using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Collections;
using Cogito.Composition.Scoping;
using Cogito.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Filters the underlying catalog for exports available in the specified scope.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public class ScopeCatalog<TScope> :
        ScopeCatalog
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public ScopeCatalog(ComposablePartCatalog parent)
            : base(parent)
        {
            IncludeScope(typeof(TScope));
        }

    }

    /// <summary>
    /// Implements a <see cref="ComposablePartCatalog"/> that exposes parts from the given parent <see
    /// cref="ComposablePartCatalog"/> that are within one of the supported scopes.
    /// </summary>
    public abstract class ScopeCatalog :
        ComposablePartCatalog
    {

        readonly ComposablePartCatalog parent;
        readonly HashSet<Type> scopes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public ScopeCatalog(ComposablePartCatalog parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            this.parent = parent;
        }

        /// <summary>
        /// Gets the part definitions that are contained in the catalog.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return GetParts(); }
        }

        /// <summary>
        /// Implements the retrieval of parts from this catalog.
        /// </summary>
        /// <returns></returns>
        IQueryable<ComposablePartDefinition> GetParts()
        {
            return parent.Parts.Where(i => Filter(i));
        }

        /// <summary>
        /// Includes the specified scope with this catalog.
        /// </summary>
        /// <param name="type"></param>
        public void IncludeScope(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);

            foreach (var i in GetScopeTypes(type))
                scopes.Add(i);
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

            return scopes.Any() ? GetScopes(definition).Any(i => scopes.Contains(i.ScopeType)) : !GetScopes(definition).Any();
        }

        /// <summary>
        /// Extracts the scope attributes from the given definition.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        IEnumerable<PartScopeAttribute> GetScopes(ComposablePartDefinition definition)
        {
            return (IEnumerable<PartScopeAttribute>)definition.Metadata.GetOrDefault(CompositionConstants.ScopeMetadataKey);
        }

    }

}
