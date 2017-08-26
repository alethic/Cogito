using System.Collections.Generic;
using System.IO;

using Cogito.Collections;

namespace Cogito.IO.Media.Providers
{

    /// <summary>
    /// Maps common image extension to media types.
    /// </summary>
    public class ImageMediaTypeProvider :
        IMediaTypeProvider
    {

        readonly static Dictionary<string, MediaRange> map = new Dictionary<string, MediaRange>()
        {
            { "gif", "image/gif" },
            { "jpeg", "image/jpeg" },
            { "jpg", "image/jpeg" },
            { "png", "image/png" },
            { "tiff", "image/tiff" },
            { "tif", "image/tiff" },
        };

        public IEnumerable<MediaRange> Resolve(string name)
        {
            var extension = Path.GetExtension(name);
            if (extension == null)
                yield break;

            var mediaRange = map.GetOrDefault(extension.TrimStart('.'));
            if (mediaRange != null)
                yield return mediaRange;
        }

    }

}
