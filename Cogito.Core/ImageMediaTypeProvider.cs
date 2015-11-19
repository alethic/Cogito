using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

using Cogito.Collections;

namespace Cogito
{

    [Export(typeof(IMediaTypeProvider))]
    public class ImageMediaTypeProvider :
        IMediaTypeProvider
    {

        Dictionary<string, MediaType> map = new Dictionary<string, MediaType>()
        {
            { "gif", "image/gif" },
            { "jpeg", "image/jpeg" },
            { "jpg", "image/jpeg" },
            { "png", "image/png" },
            { "tiff", "image/tiff" },
            { "tif", "image/tiff" },
        };

        public IEnumerable<MediaType> Resolve(string name)
        {
            var extension = Path.GetExtension(name);
            if (extension == null)
                yield break;

            var mediaType = map.GetOrDefault(extension.TrimStart('.'));
            if (mediaType != null)
                yield return mediaType;
        }

    }

}
