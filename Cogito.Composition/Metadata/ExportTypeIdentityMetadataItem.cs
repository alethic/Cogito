using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Provides the ExportTypeIdentity metadata item for a type.
    /// </summary>
    class ExportTypeIdentityMetadataItem : IMetadataItem
    {

        Type type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        public ExportTypeIdentityMetadataItem(Type type)
        {
            this.type = type;
        }
        
        string IMetadataItem.Key
        {
            get { return CompositionConstants.ExportTypeIdentityMetadataName; }
        }

        object IMetadataItem.Value
        {
            get { return AttributedModelServices.GetTypeIdentity(type); }
        }

    }

}
