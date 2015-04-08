using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Xaml;

using Cogito.Composition.Configuration;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Provides access to containers configured by name.
    /// </summary>
    public static class ContainerManager
    {

        readonly static object sync = new object();
        readonly static ConcurrentDictionary<string, CompositionContainer> containers;
        readonly static string defaultContainerName;
        static CompositionContainer defaultContainer;

        /// <summary>
        /// Initializes the static type.
        /// </summary>
        static ContainerManager()
        {
            defaultContainerName = "Default";
            containers = new ConcurrentDictionary<string, CompositionContainer>();

            var s = ConfigurationSection.GetDefaultSection();
            if (s != null)
                defaultContainerName = s.Containers.Default ?? defaultContainerName;

            // static container instances need to be disposed of when AppDomain shutdown
            AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
        }

        /// <summary>
        /// Invoked when the <see cref="AppDomain"/> is being unloaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        static void CurrentDomain_DomainUnload(object sender, EventArgs args)
        {
            // dispose of named containers
            foreach (var container in containers)
                TryDispose(container.Value);

            // dispose of default container
            if (defaultContainer != null)
                TryDispose(defaultContainer);
        }

        static void TryDispose(IDisposable disposable)
        {
            Contract.Requires<ArgumentNullException>(disposable != null);

            try
            {
                disposable.Dispose();
            }
            catch (Exception e)
            {
                e.Trace();
            }
        }

        /// <summary>
        /// Gets the container configured with the specified key.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CompositionContainer GetContainer(string name)
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
                var c = XamlServices.Load(l.Xaml.CreateReader()) as CompositionContainer;
                if (c == null)
                    throw new IndexOutOfRangeException("Unknown container name.");

                return c;
            });
        }

        /// <summary>
        /// Gets the default container.
        /// </summary>
        /// <returns></returns>
        public static CompositionContainer GetDefaultContainer()
        {
            Contract.Ensures(Contract.Result<CompositionContainer>() != null);

            lock (sync)
                return defaultContainer ?? (defaultContainer = new DefaultCompositionContainer());
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
