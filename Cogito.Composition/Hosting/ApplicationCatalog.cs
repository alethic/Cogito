using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Discovers attributed parts in the dynamic link library (DLL) and EXE files in an application's directory and path.
    /// </summary>
    public class ApplicationCatalog :
        ComposablePartCatalog
    {

        readonly AggregateCatalog catalog;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ApplicationCatalog()
            : base()
        {
            this.catalog = new AggregateCatalog(GetCatalogs(null));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public ApplicationCatalog(ReflectionContext reflectionContext)
        {
            Contract.Requires<ArgumentNullException>(reflectionContext != null);

            this.catalog = new AggregateCatalog(GetCatalogs(reflectionContext));
        }

        /// <summary>
        /// Gets the catalogs to aggregate.
        /// </summary>
        /// <param name="reflectionContext"></param>
        /// <returns></returns>
        IEnumerable<ComposablePartCatalog> GetCatalogs(ReflectionContext reflectionContext)
        {
            var location = AppDomain.CurrentDomain.BaseDirectory;
            if (location == null)
                throw new NullReferenceException();

            yield return CreateCatalog(location, "*.exe", reflectionContext);
            yield return CreateCatalog(location, "*.dll", reflectionContext);
        }

        /// <summary>
        /// Creates a new catalog.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="pattern"></param>
        /// <param name="reflectionContext"></param>
        /// <returns></returns>
        ComposablePartCatalog CreateCatalog(string location, string pattern, ReflectionContext reflectionContext)
        {
            Contract.Requires<ArgumentNullException>(location != null);
            Contract.Requires<ArgumentNullException>(pattern != null);

            if (reflectionContext != null)
                return new DirectoryCatalog(location, pattern, reflectionContext);
            else
                return new DirectoryCatalog(location, pattern);
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return catalog.Parts; }
        }

    }

}
