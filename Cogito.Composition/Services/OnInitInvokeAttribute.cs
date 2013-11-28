using System;
using System.ComponentModel.Composition;

namespace Cogito.Composition.Services
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnInitInvokeAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnInitInvokeAttribute()
            : base(typeof(IOnInitInvoke))
        {

        }

    }

}
