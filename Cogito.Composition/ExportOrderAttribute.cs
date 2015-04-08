using System;
using System.ComponentModel.Composition;

namespace Cogito.Composition
{

    /// <summary>
    /// Attaches an Order metadata property to the export.
    /// </summary>
    [MetadataAttribute]
    public class ExportOrderAttribute :
        Attribute,
        IOrderedExportMetadata
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ExportOrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; set; }

    }

}
