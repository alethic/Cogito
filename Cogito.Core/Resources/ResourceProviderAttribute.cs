using System;
using System.ComponentModel.Composition;

namespace Cogito.Resources
{

    /// <summary>
    /// Exports a <see cref="IResourceProvider"/> type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ResourceProviderAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <returns></returns>
        public ResourceProviderAttribute()
            :base(typeof(IResourceProvider))
        {

        }

    }

}
