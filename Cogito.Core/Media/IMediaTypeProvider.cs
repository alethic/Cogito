using System.Collections.Generic;

namespace Cogito.Media
{

    /// <summary>
    /// Provides <see cref="MediaType"/> resolution.
    /// </summary>
    public interface IMediaTypeProvider
    {

        /// <summary>
        /// Attempts to resolve the available <see cref="MediaType"/>s from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<MediaType> Resolve(string name);

    }

}
