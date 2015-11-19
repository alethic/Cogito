using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Wraps one export provider without attaching to the parent export provider.
    /// </summary>
    public class NonRecomposableExportProvider :
        ExportProvider
    {

        readonly ExportProvider parent;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public NonRecomposableExportProvider(ExportProvider parent)
        {
            this.parent = parent;
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return parent.GetExports(definition, atomicComposition);
        }

    }

}
