using System.Collections.Generic;

namespace Cogito
{

    public static class ObjectExtensions
    {

        /// <summary>
        /// Returns an enumerator which yields this object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<T> Yield<T>(this T self)
        {
            yield return self;
        }

    }

}
