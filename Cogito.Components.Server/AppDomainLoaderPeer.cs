using System;

namespace Cogito.Components.Server
{

    /// <summary>
    /// First class started in the <see cref="AppDomain"/>.
    /// </summary>
    public class AppDomainLoaderPeer :
        MarshalByRefObject
    {
        
        readonly ComponentManagerHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AppDomainLoaderPeer()
        {
            this.host = new ComponentManagerHost();
        }

        /// <summary>
        /// Loads all the loaders.
        /// </summary>
        public bool Load()
        {
            return host.Load();
        }

        /// <summary>
        /// Unloads all the loaders.
        /// </summary>
        public bool Unload()
        {
            return host.Unload();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }

}
