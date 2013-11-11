using System.Collections.Generic;
using System.Linq;

using Nancy;

namespace Cogito.Nancy
{

    /// <summary>
    /// Obtains key-value pairs from the query arguments.
    /// </summary>
    public class FormKeyValuePairProvider : IKeyValueProvider
    {

        public IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(NancyContext context)
        {
            return ((IEnumerable<string>)context.Request.Form)
                .Select(i => new KeyValuePair<string, object>(i, context.Request.Form[i].Value));
        }

    }

}
