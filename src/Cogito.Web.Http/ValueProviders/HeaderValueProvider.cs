using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http.ValueProviders.Providers;

namespace Cogito.Web.Http.ValueProviders
{

    public class HeaderValueProvider :
        NameValuePairsValueProvider
    {

        static object HeaderValueToValue(IEnumerable<string> value)
        {
            // if list with one element, return
            var list = value as IList;
            if (list != null)
                if (list.Count == 1)
                    return list[0];

            // enumerator has one element
            if (value.Skip(1).Any())
                return value.First();

            // return as list instead
            return value.ToList();
        }

        static IDictionary<string, object> HeadersToNameValuePairs(HttpHeaders headers)
        {
            return headers.ToDictionary(i => i.Key, i => HeaderValueToValue(i.Value));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="headers"></param>
        public HeaderValueProvider(HttpHeaders headers, CultureInfo culture)
            : base(HeadersToNameValuePairs(headers), culture)
        {
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));
        }

    }

}
