using System.Collections.Generic;

namespace Cogito.Negotiation.Tests.Negotiators
{

    public class TransitionAB :
        IConnector
    {

        public IEnumerable<INegotiator> Configure()
        {
            yield return Negotiator.Connect<StateA, StateB>(_ => new StateB(_.Value))
                .WithWeight(1);
        }

    }

}
