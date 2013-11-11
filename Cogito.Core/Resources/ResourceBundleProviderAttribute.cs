using System;
using System.ComponentModel.Composition;

namespace Cogito.Resources
{

    /// <summary>
    /// Exports a <see cref="IResourceBundleProvider"/> type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ResourceBundleProviderAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <returns></returns>
        public ResourceBundleProviderAttribute()
            : base(typeof(IResourceBundleProvider))
        {

        }

    }

}
