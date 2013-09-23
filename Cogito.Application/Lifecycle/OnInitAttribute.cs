using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnInitAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnInitAttribute(Type type)
            : base(typeof(IOnInit<>).MakeGenericType(type))
        {

        }

    }

}
