using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using Cogito.Composition.Metadata;
using Cogito.Composition.Reflection;

using mef = System.ComponentModel.Composition;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Provides exports for types which are not decorated.
    /// </summary>
    public class ConcreteTypeExportProvider : ExportProvider
    {

        readonly ConcreteTypeReflectionContext reflectionContext;
        readonly AggregateCatalog catalog;
        readonly CatalogExportProvider provider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public ConcreteTypeExportProvider()
        {
            this.reflectionContext = new ConcreteTypeReflectionContext();
            this.catalog = new AggregateCatalog();
            this.provider = new CatalogExportProvider(catalog);
        }

        /// <summary>
        /// Container from which additional exports are provided.
        /// </summary>
        public ExportProvider SourceProvider
        {
            get { return provider.SourceProvider; }
            set { Contract.Requires<ArgumentNullException>(value != null); provider.SourceProvider = value; }
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            // attempt to look up the type by contract name
            var type = ContractTypeServices.ResolveContractName(definition.ContractName);
            if (type == null)
                yield break;

            // only concrete types supported
            if (!type.IsClass || type.IsAbstract)
                yield break;

            // simple contract name check
            if (definition.ContractName != AttributedModelServices.GetContractName(type))
                yield break;

            // metadata that would be used
            var metadata = new Dictionary<string, object>()
            {
                { mef.Hosting.CompositionConstants.ExportTypeIdentityMetadataName, AttributedModelServices.GetTypeIdentity(type)}
            };

            // would we be satisfied by a hypothetical export?
            if (definition.IsConstraintSatisfiedBy(new ExportDefinition(definition.ContractName, metadata)))
            {
                var exports = provider.GetExports(definition).ToList();
                if (exports.Count == 0)
                    catalog.Catalogs.Add(new TypeCatalog(new[] { type }, reflectionContext));

                foreach (var export in exports)
                    yield return export;
            }
        }

        /// <summary>
        /// Creates a new provider 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ExportProvider CreateTypeExportProvider(Type type)
        {
            return new CatalogExportProvider(new TypeCatalog(new[] { type }, reflectionContext))
            {
                SourceProvider = SourceProvider,
            };
        }

    }

}
