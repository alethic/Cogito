using System.Collections.Generic;

namespace Cogito.Negotiation.Tests.Negotiators
{

    class StateConnectorProvider :
        IConnectorProvider
    {

        IConnector[] connectors = new IConnector[]
        {
            new TransitionAB(),
            new TransitionBC(),
            new TransitionCD(),
        };

        public StateConnectorProvider()
            : base()
        {

        }

        public IEnumerable<IConnector> GetConnectors()
        {
            return connectors;
        }

    }

}
