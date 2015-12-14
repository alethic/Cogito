using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Returns the given object as a finished task.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Task<T> AsTask<T>(this T self)
        {
            return Task.FromResult<T>(self);
        }


    }

}
