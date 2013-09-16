using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnAfterStartAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnAfterStartAttribute(Type applicationType)
            : base(typeof(IOnAfterStart<>).MakeGenericType(applicationType))
        {

        }

    }

}
