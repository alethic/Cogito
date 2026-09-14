using System;
using System.Collections.Generic;
using System.Linq;

#if NET451 || NET462 || NET47
using Cogito.Linq;
#endif

namespace Cogito.IO.Media
{

    /// <summary>
    /// Default <see cref="IMediaTypeResolver"/> implementation that attempts to resolve media types from
    /// <see cref="IMediaTypeProvider"/> instances.
    /// </summary>
    public class DefaultMediaTypeResolver :
        IMediaTypeResolver
    {

        readonly IEnumerable<IMediaTypeProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        public DefaultMediaTypeResolver(
            IEnumerable<IMediaTypeProvider> providers)
        {
            if (providers == null)
                throw new ArgumentNullException(nameof(providers));

            this.providers = providers;
        }

        public MediaRange Resolve(string name)
        {
            return ResolveMany(name).FirstOrDefault();
        }

        public IEnumerable<MediaRange> ResolveMany(string name)
        {
            return providers.SelectMany(i => i.Resolve(name)).Append((MediaRange)"application/octet-stream");
        }

    }

}
