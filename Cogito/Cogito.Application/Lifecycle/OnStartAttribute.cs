using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnStartAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnStartAttribute(Type applicationType)
            : base(typeof(IOnStart<>).MakeGenericType(applicationType))
        {

        }

    }

}
