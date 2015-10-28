using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Main entry point for composition.
    /// </summary>
    [Export]
    public class ServiceLoader
    {

        readonly AppDomainLoader[] loaders;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        [ImportingConstructor]
        public ServiceLoader(
            [ImportMany] IEnumerable<IApplicationInfoProvider> providers)
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.loaders = providers
                .SelectMany(i => i.GetApplications())
                .Select(i => new AppDomainLoader(i))
                .ToArray();
        }

        /// <summary>
        /// Starts all of the applications.
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            return loaders.All(i => i.Load());
        }

        /// <summary>
        /// Stops all of the applications.
        /// </summary>
        /// <returns></returns>
        public bool Unload()
        {
            return loaders.All(i => i.Unload());
        }

    }

}
