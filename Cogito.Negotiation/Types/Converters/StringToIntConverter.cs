using System.Collections.Generic;

namespace Cogito.Negotiation.Types.Converters
{

    public class StringToIntConverter :
        IConnector
    {

        IEnumerable<INegotiator> IConnector.Configure()
        {
            yield return Negotiator.Connect<string, int>(_ => int.Parse(_))
                .OfContentType("text/xml")
                .AsContentType("application/pdf")
                .WithWeight(1);
        }

    }

}
