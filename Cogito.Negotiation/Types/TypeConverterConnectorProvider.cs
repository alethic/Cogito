using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Linq;

namespace Cogito.Negotiation.Types
{

    /// <summary>
    /// Provides available <see cref="ITypeConverter"/>s to the negotiation framework.
    /// </summary>
    [ConnectorProvider]
    public class TypeConverterConnectorProvider :
        IConnectorProvider
    {

        /// <summary>
        /// Gets all <see cref="Type"/>s available in the <see cref="AppDomain"/>.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<Type> GetAppDomainTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(i => !i.IsDynamic)
                .SelectMany(i => i.GetExportedTypes())
                .Where(i => !i.IsGenericTypeDefinition)
                .Where(i => i.IsClass || i.IsValueType);
        }

        readonly IEnumerable<Type> availableTypes;
        readonly IEnumerable<TypeConverterConnector> connectors;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="types"></param>
        public TypeConverterConnectorProvider(
            IEnumerable<Type> types)
        {
            this.availableTypes = types;
            this.connectors = GetConnectors().Tee(true);
        }

        /// <summary>s
        /// Initalizes a new instance.
        /// </summary>
        [ImportingConstructor]
        public TypeConverterConnectorProvider()
            : this(GetAppDomainTypes())
        {

        }

        /// <summary>
        /// Gets connections for every available <see cref="TypeDescriptor"/> on the set of available types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TypeConverterConnector> GetConnectors()
        {
            // return an adapter for each converter that can convert to a known type
            foreach (var type in availableTypes)
            {
                var converter = TypeDescriptor.GetConverter(type);
                if (converter == null)
                    continue;

                yield return new TypeConverterConnector(converter, type, availableTypes);
            }
        }

        IEnumerable<IConnector> IConnectorProvider.GetConnectors()
        {
            return connectors;
        }

    }

}
