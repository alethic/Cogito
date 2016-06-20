using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

using Cogito.Collections;

namespace Cogito.IO.Media.Providers
{

    [Export(typeof(IMediaTypeProvider))]
    public class TextMediaTypeProvider :
        IMediaTypeProvider
    {

        readonly static Dictionary<string, MediaRange> map = new Dictionary<string, MediaRange>()
        {
            { "css", "text/css" },
            { "html", "text/html" },
            { "js", "application/javascript" },
            { "xml", "text/xml" },
        };

        public IEnumerable<MediaRange> Resolve(string name)
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
