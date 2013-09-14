using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Linq
{

    public static class EnumerableExtensions
    {

        public static IEnumerable EmptyIfNull(this IEnumerable source)
        {
            return source ?? Enumerable.Empty<object>();
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

    }

}
