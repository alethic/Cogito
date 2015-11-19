using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Cogito.Collections
{

    public static class NameValueCollectionExtensions
    {

        public static Dictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            return source.Cast<string>().ToDictionary(i => i, i => source[i]);
        }

    }

}
