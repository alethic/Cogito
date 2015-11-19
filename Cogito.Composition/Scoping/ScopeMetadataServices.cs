using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Cogito.Collections;
using Cogito.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Provides services for working with scope metadata.
    /// </summary>
    public static class ScopeMetadataServices
    {

        /// <summary>
        /// Gets the supported scopes of the given <see cref="ComposablePartDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetScopes(ComposablePartDefinition definition)
        {
            var o = definition.Metadata.GetOrDefault(CompositionConstants.ScopeMetadataKey);

            if (o is Type)
                return new Type[] { (Type)o };

            if (o is IEnumerable<Type>)
                return (IEnumerable<Type>)o;

            return Enumerable.Empty<Type>();
        }

        /// <summary>
        /// Gets the <see cref="Visibility"/> of the given <see cref="ExportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public static Visibility GetVisibility(ExportDefinition definition)
        {
            var o = definition.Metadata.GetOrDefault(CompositionConstants.VisibilityMetadataKey);

            if (o is Visibility)
                return (Visibility)o;

            if (o is IEnumerable<Visibility>)
                return ((IEnumerable<Visibility>)o).Any(i => i == Visibility.Inherit) ? Visibility.Inherit : Visibility.Local;

            return Visibility.Inherit;
        }

    }

}
