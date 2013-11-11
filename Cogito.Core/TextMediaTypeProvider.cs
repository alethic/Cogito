using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

using Cogito.Collections;

namespace Cogito
{

    [Export(typeof(IMediaTypeProvider))]
    public class WebMediaTypeProvider :
        IMediaTypeProvider
    {

        Dictionary<string, MediaType> map = new Dictionary<string, MediaType>()
        {
            { "css", "text/css" },
            { "html", "text/html" },
            { "js", "application/javascript" },
            { "xml", "text/xml" },
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
