using System;

namespace Cogito.Resources
{

    /// <summary>
    /// Marks the <see cref="Assembly"/> as a bundle provider.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyResourceBundleAttribute :
        Attribute
    {

        readonly string prefix;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="prefix">Specifies a resource name prefix to strip from resources.</param>
        public AssemblyResourceBundleAttribute(string prefix)
        {
            this.prefix = prefix;
        }

        /// <summary>
        /// Species a resource name prefix to strip from resources.
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
        }

    }

}
