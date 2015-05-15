using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito.ServiceBus.MassTransit
{

    [CollectionDataContract(ItemName = "Type")]
    public class EnvelopeMessageTypeList :
        List<string>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public EnvelopeMessageTypeList()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public EnvelopeMessageTypeList(IEnumerable<string> source)
            : base(source)
        {
            Contract.Requires<ArgumentNullException>(source != null);
        }

    }

}
