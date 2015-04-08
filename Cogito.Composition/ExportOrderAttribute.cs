using System;
using System.ComponentModel.Composition;

namespace Cogito.Composition
{

    /// <summary>
    /// Attaches an Order metadata property to the export.
    /// </summary>
    [MetadataAttribute]
    public class ExportOrderAttribute :
        Attribute
    {

        readonly int order;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ExportOrderAttribute(int order)
        {
            Priority = order;
        }

        public int Priority { get; set; }

    }

}
