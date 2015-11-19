using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition
{

    /// <summary>
    /// Default <see cref="IExportResolver"/> implementation.
    /// </summary>
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(IExportResolver))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class ExportResolver :
        IExportResolver
    {

        readonly IContainerProvider provider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        [ImportingConstructor]
        public ExportResolver(IContainerProvider provider)
        {
            this.provider = provider;
        }

        public Export Resolve(Type type)
        {
            return ResolveMany(type).FirstOrDefault();
        }

        public IEnumerable<Export> ResolveMany(Type type)
        {
            return provider.GetContainer().GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(type),
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.Any));
        }

    }

}
