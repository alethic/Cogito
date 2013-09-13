using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Generates metadata for a <see cref="Type"/> based contract.
    /// </summary>
    class ExportTypeIdentityMetadata : Metadata
    {

        Type contractType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="contractType"></param>
        public ExportTypeIdentityMetadata(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);

            this.contractType = contractType;
        }

        public override IEnumerator<IMetadataItem> GetEnumerator()
        {
            yield return new ExportTypeIdentityMetadataItem(contractType);
        }

    }

}
