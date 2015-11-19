using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Reflection;

using Cogito.Composition.Services;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides a <see cref="ComposablePartCatalog"/> of Nancy Razor views for the specified <see cref="Assembly"/>.
    /// </summary>
    public abstract class NancyRazorCatalogProvider :
        ICatalogProvider
    {

        readonly Assembly assembly;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        public NancyRazorCatalogProvider(Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);

            this.assembly = assembly;
        }

        public IEnumerable<ComposablePartCatalog> GetCatalogs()
        {
            yield return new NancyRazorViewAssemblyCatalog(assembly);
        }

    }

}
