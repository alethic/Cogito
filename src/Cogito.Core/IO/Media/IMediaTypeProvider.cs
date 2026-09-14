using System.Collections.Generic;

namespace Cogito.IO.Media
{

    /// <summary>
    /// Provides <see cref="MediaRange"/> resolution.
    /// </summary>
    public interface IMediaTypeProvider
    {

        /// <summary>
        /// Attempts to resolve the available <see cref="MediaRange"/>s from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<MediaRange> Resolve(string name);

    }

}
