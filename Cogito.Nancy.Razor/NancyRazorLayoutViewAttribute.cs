using System;
using System.ComponentModel.Composition;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Exports the view as a <see cref="INancyRazorLayoutView"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class NancyRazorLayoutViewAttribute :
        InheritedExportAttribute, 
        INancyRazorLayoutViewMetadata
    {

        readonly string name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyRazorLayoutViewAttribute()
            : base(typeof(INancyRazorLayoutView<>))
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyRazorLayoutViewAttribute(string name)
            : base(typeof(INancyRazorLayoutView<>))
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

    }

}
