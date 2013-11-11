using System;
using System.ComponentModel.Composition;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Exports the view as a <see cref="INancyRazorView"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class NancyRazorViewAttribute : ExportAttribute, INancyRazorViewMetadata
    {

        string name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        public NancyRazorViewAttribute(string name)
            : base(typeof(INancyRazorView<>))
        {
            this.name = name;
        }

        /// <summary>
        /// Name of the view.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

    }

}
