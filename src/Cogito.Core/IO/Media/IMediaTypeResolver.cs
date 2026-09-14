using System.Collections.Generic;

namespace Cogito.IO.Media
{

    /// <summary>
    /// Interface to resolve media types.
    /// </summary>
    public interface IMediaTypeResolver
    {

        /// <summary>
        /// Attempts to resolve a <see cref="MediaRange"/> from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        MediaRange Resolve(string name);

        /// <summary>
        /// Attempts to resolve the available <see cref="MediaRange"/>s from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<MediaRange> ResolveMany(string name);

    }

}
