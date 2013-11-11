using System;
using System.ComponentModel.Composition;

namespace Cogito.Negotiation
{
    
    /// <summary>
    /// Exports <see cref="INegotiatorProvider"/>s.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NegotiatorProviderAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NegotiatorProviderAttribute()
            : base(typeof(INegotiatorProvider))
        {

        }

    }

}
