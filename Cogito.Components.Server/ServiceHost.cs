using System.Linq;

using Cogito.Composition.Hosting;

using Topshelf;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Implements the Topshelf <see cref="ServiceControl"/> instance.
    /// </summary>
    public class ServiceHost :
        ServiceHostBase
    {

        readonly AppDomainLoader[] loaders;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ServiceHost()
        {
            this.loaders = ContainerManager.GetDefaultTypeResolver()
                .ResolveMany<IApplicationInfoProvider>()
                .SelectMany(i => i.GetApplications())
                .Select(i => new AppDomainLoader(i))
                .ToArray();
        }

        public override bool Start(HostControl hostControl)
        {
            return loaders.All(i => i.Load());
        }

        public override bool Stop(HostControl hostControl)
        {
            return loaders.All(i => i.Unload());
        }

    }

}
