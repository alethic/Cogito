using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using Cogito.Composition.Scoping;
using Cogito.Core;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Makes the <see cref="ContainerExport"/>'s container available to the container itself in various ways.
    /// </summary>
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(IContainerProvider))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class ContainerProvider
        : IContainerProvider
    {

        readonly Lazy<ContainerExport> export;
        readonly RefManager<CompositionContainer> manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="export"></param>
        [ImportingConstructor]
        public ContainerProvider(Lazy<ContainerExport> export)
        {
            Contract.Requires<ArgumentNullException>(export != null);

            this.export = export;
            this.manager = new RefManager<CompositionContainer>(() => export.Value.Item, () => export.Value.Item.Dispose());
        }

        /// <summary>
        /// Gets the current composition container.
        /// </summary>
        /// <returns></returns>
        [Export]
        [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
        public CompositionContainer GetContainer()
        {
            return export.Value.Item;
        }

        /// <summary>
        /// Gets a reference to the current composition container.
        /// </summary>
        /// <returns></returns>
        public Ref<CompositionContainer> GetContainerRef()
        {
            return manager.Ref();
        }

    }

}
