using System;

namespace Cogito.Resources
{

    /// <summary>
    /// Indicates a dot-separated path of assembly resources.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyResourcePathAttribute :
        Attribute
    {

        readonly string path;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path">Specifies a dot-separated path to include when exporting resources.</param>
        public AssemblyResourcePathAttribute(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Specifies a dot-separated path to include when exporting resources.
        /// </summary>
        public string Path
        {
            get { return path; }
        }

    }

}
