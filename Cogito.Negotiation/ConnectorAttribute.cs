using System;
using System.ComponentModel.Composition;

namespace Cogito.Negotiation
{
    
    /// <summary>
    /// Exports <see cref="IConnector"/>s.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConnectorAttribute :
        ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConnectorAttribute()
            : base(typeof(IConnector))
        {

        }

    }

}
