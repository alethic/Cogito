using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Xaml;

namespace Cogito.Composition.Hosting.Configuration
{

    /// <summary>
    /// Provides access to the containers by configuration.
    /// </summary>
    public static class ConfigurationManager
    {

        readonly static ConcurrentDictionary<string, System.ComponentModel.Composition.Hosting.CompositionContainer> containers =
            new ConcurrentDictionary<string, System.ComponentModel.Composition.Hosting.CompositionContainer>();

        /// <summary>
        /// Gets the container configured with the specified key.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static System.ComponentModel.Composition.Hosting.CompositionContainer GetContainer(string name)
        {
            Contract.Requires<ArgumentNullException>(name != null);

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
                var c = XamlServices.Load(l.Xaml.CreateReader()) as System.ComponentModel.Composition.Hosting.CompositionContainer;
                if (c == null)
                    throw new IndexOutOfRangeException("Unknown container name.");

                return c;
            });
        }

    }

}
