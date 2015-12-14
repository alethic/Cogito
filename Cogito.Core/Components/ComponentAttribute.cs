using System;
using System.ComponentModel.Composition;

namespace Cogito.Components
{

    /// <summary>
    /// Exports a given <see cref="IComponent"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ComponentAttribute()
            : base(typeof(IComponent))
        {

        }

    }

}
