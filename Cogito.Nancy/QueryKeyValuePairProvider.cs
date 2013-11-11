using System.Collections.Generic;
using System.Linq;

using Nancy;

namespace Cogito.Nancy
{

    /// <summary>
    /// Obtains key-value pairs from the query arguments.
    /// </summary>
    public class QueryKeyValuePairProvider : IKeyValueProvider
    {

        public IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(NancyContext context)
        {
            return ((IEnumerable<string>)context.Request.Query)
                .Select(i => new KeyValuePair<string, object>(i, context.Request.Query[i].Value));
        }

    }

}
