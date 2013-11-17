using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Filters the resulting exports of another <see cref="ExportProvider"/>.
    /// </summary>
    public class FilteredExportProvider : ExportProvider
    {

        readonly ExportProvider provider;
        readonly Func<ExportDefinition, bool> filter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        public FilteredExportProvider(ExportProvider provider, Func<ExportDefinition, bool> filter)
        {
            Contract.Requires<ArgumentNullException>(provider != null);
            Contract.Requires<ArgumentNullException>(filter != null);

            this.provider = provider;
            this.filter = filter;

            this.provider.ExportsChanging += provider_ExportsChanging;
            this.provider.ExportsChanged += provider_ExportsChanged;
        }

        void provider_ExportsChanging(object sender, ExportsChangeEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);

            OnExportsChanging(new ExportsChangeEventArgs(
                args.AddedExports.Where(i => filter(i)),
                args.RemovedExports.Where(i => filter(i)),
                args.AtomicComposition));
        }

        void provider_ExportsChanged(object sender, ExportsChangeEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);

            OnExportsChanging(new ExportsChangeEventArgs(
                args.AddedExports.Where(i => filter(i)),
                args.RemovedExports.Where(i => filter(i)),
                args.AtomicComposition));
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return provider.TryGetExports(definition, atomicComposition).Where(i => filter(i.Definition));
        }

    }

}
