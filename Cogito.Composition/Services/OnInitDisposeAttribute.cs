using System;
using System.ComponentModel.Composition;

namespace Cogito.Composition.Services
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnDisposeInvokeAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnDisposeInvokeAttribute()
            : base(typeof(IOnDisposeInvoke))
        {

        }

    }

}
