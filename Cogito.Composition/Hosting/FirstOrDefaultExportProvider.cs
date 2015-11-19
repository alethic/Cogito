using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Implements a <see cref="ExportProvider"/> that allows Imports (ExactlyOne) to be resolved to the first found
    /// item instead of erroring.
    /// </summary>
    public class FirstOrDefaultExportProvider : PassThruExportProvider
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        public FirstOrDefaultExportProvider(ExportProvider provider)
            : base(provider)
        {
            Contract.Requires<ArgumentNullException>(provider != null);
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            // replace ZeroOrOne with ZeroOrMore to prevent errors down the chain; we'll grab the first
            if (definition.Cardinality == ImportCardinality.ExactlyOne)
                return base.GetExportsCore(new ImportDefinition(
                    definition.Constraint,
                    definition.ContractName,
                    ImportCardinality.ZeroOrMore,
                    definition.IsRecomposable,
                    definition.IsPrerequisite,
                    definition.Metadata), atomicComposition)
                    .Take(1);

            return base.GetExportsCore(definition, atomicComposition);
        }

    }

}
