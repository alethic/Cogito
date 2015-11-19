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
    public class ServiceManager
    {

        readonly AppDomainLoader[] loaders;
        readonly IServiceHook[] hooks;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        /// <param name="hooks"></param>
        [ImportingConstructor]
        public ServiceManager(
            [ImportMany] IEnumerable<IApplicationInfoProvider> providers,
            [ImportMany] IEnumerable<IServiceHook> hooks)
        {
            Contract.Requires<ArgumentNullException>(providers != null);
            Contract.Requires<ArgumentNullException>(hooks != null);

            // generate app loaders
            this.loaders = providers
                .SelectMany(i => i.GetApplications())
                .Select(i => new AppDomainLoader(i))
                .ToArray();

            // compile hooks
            this.hooks = hooks
                .ToArray();
        }

        /// <summary>
        /// Starts all of the applications.
        /// </summary>
        /// <returns></returns>
        public bool Start(IServiceControl control)
        {
            // signal starting
            foreach (var hook in hooks)
                hook.OnStarting(control);

            // load all loaders
            var b = loaders.All(i => i.Load());

            // signal started
            foreach (var hook in hooks)
                hook.OnStarted(control);

            return b;
        }

        /// <summary>
        /// Stops all of the applications.
        /// </summary>
        /// <returns></returns>
        public bool Stop(IServiceControl control)
        {
            // signal stopping
            foreach (var hook in hooks)
                hook.OnStopping(control);

            // unload all loaders
            var b = loaders.All(i => i.Unload());

            // signal stopped
            foreach (var hook in hooks)
                hook.OnStopped(control);

            return b;
        }

    }

}
