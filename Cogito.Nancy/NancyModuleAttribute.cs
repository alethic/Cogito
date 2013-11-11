using System;
using System.ComponentModel.Composition;

using Nancy;

namespace Cogito.Nancy
{

    /// <summary>
    /// Exports the class as an <see cref="INancyModule"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NancyModuleAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyModuleAttribute()
            : base(typeof(INancyModule))
        {

        }

    }

}
