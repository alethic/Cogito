using System;

using System.ComponentModel.Composition;
using Cogito.Composition.Scoping;
using Cogito.Web;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Exports the view as a <see cref="INancyRazorView"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    [PartScope(typeof(IWebRequestScope))]
    public class NancyRazorViewAttribute :
        InheritedExportAttribute,
        INancyRazorViewMetadata
    {

        readonly string name;

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
