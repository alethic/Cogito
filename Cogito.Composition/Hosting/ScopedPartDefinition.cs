using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Describes a part that supports scoping.
    /// </summary>
    public class ScopedPartDefinition :
        ComposablePartDefinition
    {

        readonly ComposablePartDefinition parent;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public ScopedPartDefinition(ComposablePartDefinition parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            this.parent = parent;
        }

        public override ComposablePart CreatePart()
        {
            return parent.CreatePart();
        }

        public override IEnumerable<ExportDefinition> ExportDefinitions
        {
            get { return parent.ExportDefinitions; }
        }

        public override IEnumerable<ImportDefinition> ImportDefinitions
        {
            get { return parent.ImportDefinitions; }
        }

    }

}
