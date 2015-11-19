using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Cogito.Negotiation.Types
{

    /// <summary>
    /// Implements a <see cref="IConnector"/> for a given <see cref="ITypeConverter"/>.
    /// </summary>
    public class TypeConverterConnector :
        IConnector
    {

        readonly TypeConverter converter;
        readonly Type converterType;
        readonly IEnumerable<Type> availableTypes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="converter"></param>
        public TypeConverterConnector(
            TypeConverter converter,
            Type converterType,
            IEnumerable<Type> availableTypes)
        {
            Contract.Requires<ArgumentNullException>(converter != null);
            Contract.Requires<ArgumentNullException>(converterType != null);
            Contract.Requires<ArgumentNullException>(availableTypes != null);

            this.converter = converter;
            this.converterType = converterType;
            this.availableTypes = availableTypes;
        }

        public IEnumerable<INegotiator> Configure()
        {
            foreach (var availableType in availableTypes)
                if (converter.CanConvertTo(availableType))
                    yield return Negotiator.Connect(converterType, availableType, _ => converter.ConvertTo(_, availableType));
                else if (converter.CanConvertFrom(availableType))
                    yield return Negotiator.Connect(availableType, converterType, _ => converter.ConvertFrom(_));
        }

    }

}
