using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnStateChangeAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnStateChangeAttribute(Type type)
            : base(typeof(IOnStateChange<>).MakeGenericType(type))
        {

        }

    }

}
