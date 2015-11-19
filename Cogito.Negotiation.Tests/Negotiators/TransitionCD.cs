using System.Collections.Generic;

namespace Cogito.Negotiation.Tests.Negotiators
{

    public class TransitionCD :
        IConnector
    {

        public IEnumerable<INegotiator> Configure()
        {
            yield return Negotiator.Connect<StateC, StateD>(_ => new StateD(_.Value))
                .WithWeight(3);
        }

    }

}
