using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnShutdownAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnShutdownAttribute(Type type)
            : base(typeof(IOnShutdown<>).MakeGenericType(type))
        {

        }

    }

}
