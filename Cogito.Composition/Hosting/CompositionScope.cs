using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Cogito.Collections;
using Cogito.Composition.Scoping;
using Cogito.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Implements a scoped <see cref="CompositionContainer"/> using generics.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public class CompositionScope<TScope> : CompositionScope
            where TScope : IScope
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionScope(System.ComponentModel.Composition.Hosting.CompositionContainer parent)
            : base(parent, typeof(TScope))
        {

        }

    }

    /// <summary>
    /// Implements a scoped <see cref="CompositionContainer"/>.
    /// </summary>
    public class CompositionScope : CompositionContainerCore
    {

        /// <summary>
        /// Method that generates a generic type.
        /// </summary>
        static readonly MethodInfo genericCreateScopeMethod = typeof(CompositionScope)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(i => i.Name == "CreateScope")
            .Where(i => i.ContainsGenericParameters)
            .First();

        /// <summary>
        /// Creates a new <see cref="CompositionScope"/> of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public static CompositionScope CreateScope(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent,
            Type scopeType)
        {
            return (CompositionScope)genericCreateScopeMethod.MakeGenericMethod(scopeType).Invoke(null, new[] { parent });
        }

        /// <summary>
        /// Creates a new <see cref="CompositionScope"/> of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static CompositionScope<TScope> CreateScope<TScope>(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent)
            where TScope : IScope
        {
            return new CompositionScope<TScope>(parent);
        }

        HashSet<Type> scopes;
        HashSet<string> identities;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionScope(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent,
            Type scope)
            : base(
                parent: parent,
                catalog: null,
                provider: null)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            // extract boundaries from specified scope
            this.scopes = GetScopes(scope);

            // string versions of scope names
            this.identities = this.scopes
                .Select(i => AttributedModelServices.GetTypeIdentity(i))
                .ToHashSet();
        }

        /// <summary>
        /// Expands the given set of boundary types into the full set of implemented boundary types.
        /// </summary>
        /// <param name="boundaries"></param>
        /// <returns></returns>
        HashSet<Type> GetScopes(Type scope)
        {
            Contract.Requires<ArgumentNullException>(scope != null);
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scope));

            var l = new HashSet<Type>();

            // add all base types
            foreach (var i in scope.Recurse(i => i.BaseType))
                if (i != typeof(IScope))
                    if (typeof(IScope).IsAssignableFrom(i))
                        l.Add(i);

            // add all supported interfaces
            foreach (var i in scope.GetInterfaces())
                if (i != typeof(IScope))
                    if (typeof(IScope).IsAssignableFrom(i))
                        l.Add(i);

            return l;
        }

        /// <summary>
        /// Filters out parts that require a boundary that isn't established by the current scope.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        protected override bool PartFilter(ComposablePartDefinition definition)
        {
            // extract boundary data
            var b = definition.Metadata.GetOrDefault(CompositionConstants.RequiredScopeMetadataName);
            if (b == null)
                return false;

            // metadata requires a single scope
            var i = b as string;
            if (i != null)
                return identities != null ? identities.Contains(i) : false;

            // metadata requires multiple scopes
            var l = b as IEnumerable<string>;
            if (l != null)
                return identities != null ? l.All(x => identities.Contains(x)) : false;

            return false;
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, System.ComponentModel.Composition.Hosting.AtomicComposition atomicComposition)
        {
            return base.GetExportsCore(definition, atomicComposition);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }

}
