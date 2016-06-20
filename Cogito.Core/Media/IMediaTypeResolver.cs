using System.Collections.Generic;

namespace Cogito.Media
{

    /// <summary>
    /// Interface to resolve media types.
    /// </summary>
    public interface IMediaTypeResolver
    {

        /// <summary>
        /// Attempts to resolve a <see cref="MediaType"/> from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        MediaType Resolve(string name);

        /// <summary>
        /// Attempts to resolve the available <see cref="MediaType"/>s from a given file name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<MediaType> ResolveMany(string name);

    }

}
