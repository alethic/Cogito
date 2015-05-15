using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito.ServiceBus.MassTransit
{

    [CollectionDataContract(ItemName = "Header", KeyName = "Key", ValueName = "Value")]
    public class EnvelopeHeaderDictionary :
        Dictionary<string, string>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public EnvelopeHeaderDictionary()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public EnvelopeHeaderDictionary(IDictionary<string, string> source)
            : base(source)
        {
            Contract.Requires<ArgumentNullException>(source != null);
        }

    }

}
