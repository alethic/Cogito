using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Reflection
{

    /// <summary>
    /// Provides various methods for working with <see cref="Type"/> instances.
    /// </summary>
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

            // first type serves as reference hierarchy
            var t = types.FirstOrDefault();
            if (t == null)
                yield break;

            // finished signal
            var b = false;

            // check each type in hierarchy
            foreach (var a in t.GetTypeAndBaseTypes())
            {
                // finished, or all types are either equal or a subclass of current hierachy position
                if (b || types.All(i => i == a || i.IsSubclassOf(a)))
                {
                    // all remaining types are also true
                    b = true;

                    // return result
                    yield return a;
                }
            }

            throw new InvalidOperationException();
        }

    }

}
