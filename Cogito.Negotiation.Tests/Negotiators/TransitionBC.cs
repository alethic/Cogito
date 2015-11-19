using System.Collections.Generic;

namespace Cogito.Negotiation.Tests.Negotiators
{

    public class TransitionBC :
        IConnector
    {

        public IEnumerable<INegotiator> Configure()
        {
            yield return Negotiator.Connect<StateB, StateC>(_ => new StateC(_.Value))
                .WithWeight(2);
        }

    }

}
