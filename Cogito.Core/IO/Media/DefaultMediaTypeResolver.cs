﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Linq;

namespace Cogito.IO.Media
{

    /// <summary>
    /// Default <see cref="IMediaTypeResolver"/> implementation that attempts to resolve media types from
    /// <see cref="IMediaTypeProvider"/> instances.
    /// </summary>
    [Export(typeof(IMediaTypeResolver))]
    public class DefaultMediaTypeResolver :
        IMediaTypeResolver
    {

        readonly IEnumerable<IMediaTypeProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        [ImportingConstructor]
        public DefaultMediaTypeResolver(
            [ImportMany] IEnumerable<IMediaTypeProvider> providers)
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