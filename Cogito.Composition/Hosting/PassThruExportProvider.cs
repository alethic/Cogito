using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Provides a base <see cref="ExportProvider"/> implementation that defers to another <see cref="ExportProvider"/>.
    /// </summary>
    public abstract class PassThruExportProvider : 
        ExportProvider
    {

        ExportProvider provider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        public PassThruExportProvider(ExportProvider provider)
            : base()
        {
            Contract.Requires<ArgumentNullException>(provider != null);
            this.provider = provider;
            this.provider.ExportsChanging += (s, a) => OnExportsChanging(a);
            this.provider.ExportsChanged += (s, a) => OnExportsChanged(a);
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return provider.TryGetExports(definition, atomicComposition);
        }

    }

}
