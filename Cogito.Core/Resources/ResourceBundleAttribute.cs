using System;
using System.ComponentModel.Composition;

namespace Cogito.Resources
{

    /// <summary>
    /// Exports a <see cref="IResourceBundle"/> type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ResourceBundleAttribute : 
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <returns></returns>
        public ResourceBundleAttribute()
            : base(typeof(IResourceBundle))
        {

        }

    }

}
