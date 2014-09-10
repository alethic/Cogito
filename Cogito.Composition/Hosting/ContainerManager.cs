using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Xaml;

using Cogito.Composition.Hosting.Configuration;

using mef = System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Provides access to containers configured by name.
    /// </summary>
    public static class ContainerManager
    {


        readonly static ConcurrentDictionary<string, mef.CompositionContainer> containers;
        readonly static string defaultContainerName;
        static mef.CompositionContainer defaultContainer;

        /// <summary>
        /// Initializes the static type.
        /// </summary>
        static ContainerManager()
        {
            defaultContainerName = "Default";
            containers = new ConcurrentDictionary<string, mef.CompositionContainer>();

            var s = ConfigurationSection.GetDefaultSection();
            if (s != null)
                defaultContainerName = s.Containers.Default ?? defaultContainerName;
        }

        /// <summary>
        /// Gets the container configured with the specified key.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static mef.CompositionContainer GetContainer(string name)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name));

            return containers.GetOrAdd(name, _ =>
            {
                var s = ConfigurationSection.GetDefaultSection();
                if (s == null)
                    return null;

                // container collection indexed by name, and contains Xaml for a container
                var l = s.Containers[_];
                if (l == null)
                    throw new IndexOutOfRangeException("Unconfigured container name.");

                // convert xaml into object
                var c = XamlServices.Load(l.Xaml.CreateReader()) as mef.CompositionContainer;
                if (c == null)
                    throw new IndexOutOfRangeException("Unknown container name.");

                return c;
            });
        }

        /// <summary>
        /// Gets the default container.
        /// </summary>
        /// <returns></returns>
        public static mef.CompositionContainer GetDefaultContainer()
        {
            Contract.Ensures(Contract.Result<mef.CompositionContainer>() != null);

            return
                defaultContainer ??
                (defaultContainer = new DefaultCompositionContainer());
        }

        /// <summary>
        /// Gets the default type resolver.
        /// </summary>
        /// <returns></returns>
        public static ITypeResolver GetDefaultTypeResolver()
        {
            return GetDefaultContainer().GetExportedValue<ITypeResolver>();
        }

    }

}
