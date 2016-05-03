using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Reflection
{

    public static class TypeUtil
    {

        /// <summary>
        /// Returns the sequence of types that are compatible with the sequence of given types sorted by most compatible
        /// to least compatible.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetMostCompatibleTypes(IEnumerable<Type> types)
        {
            Contract.Requires<ArgumentNullException>(types != null);

            // side-by-side hierarchy of types starting at object
            var a = types.Select(i => i.GetTypeAndBaseTypes().Reverse().ToArray()).ToArray();

            // single type passed, type hierarchy itself is result
            if (a.Length == 1)
                return a[0];

            var l = new LinkedList<Type>();
            int p = -1;

            // test each hierarchy level
            while (true)
            {
                p++;

                // cut across the type arrays
                var s = a.Select(i => i.Length > p ? i[p] : null);
                var t = s.First();

                // first element must not be null
                if (t == null)
                    return l;

                // all elements match first element
                if (s.Skip(1).All(i => i == t))
                {
                    // prepend and check next
                    l.AddFirst(t);
                    continue;
                }

                // types do not match, we're finished
                return l;
            }
        }

    }

}
