using System;
using System.ComponentModel.Composition;

using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition.Services
{

    [AttributeUsage(AttributeTargets.Class)]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
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
