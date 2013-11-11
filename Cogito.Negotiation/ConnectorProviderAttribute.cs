using System;
using System.ComponentModel.Composition;

namespace Cogito.Negotiation
{
    
    /// <summary>
    /// Exports <see cref="IConnectorProvider"/>s.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConnectorProviderAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConnectorProviderAttribute()
            : base(typeof(IConnectorProvider))
        {

        }

    }

}
