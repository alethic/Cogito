using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Components
{

    /// <summary>
    /// Manages the lifecycle of <see cref="IComponent"/> instances.
    /// </summary>
    [Export(typeof(IComponentManager))]
    public class ComponentManager :
        IComponentManager
    {

        readonly IEnumerable<IComponentProvider> providers;
        readonly IEnumerable<IComponent> components;
        readonly Type[] startTypes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="components"></param>
        [ImportingConstructor]
        public ComponentManager(
            [ImportMany] IEnumerable<IComponentProvider> providers)
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.providers = providers;
            this.components = providers.SelectMany(i => i.Components).ToArray();

            // extract enabled types from configuration
            this.startTypes = ComponentConfigurationSection.GetDefaultSection().Start
                .Cast<ComponentTypeConfigurationElement>()
                .Select(i => i.Type)
                .Select(i => i.TrimOrNull())
                .Where(i => i != null)
                .Select(i => Type.GetType(i))
                .Where(i => i != null)
                .ToArray();
        }

        public void Start()
        {
            lock (components)
            {
                var e = components.Select(i => TryStart(i)).Where(i => i != null).ToArray();
                if (e.Any())
                    throw new AggregateException(e).Flatten();
            }
        }

        public void Stop()
        {
            lock (components)
            {
                var e = components.Select(i => TryStop(i)).Where(i => i != null).ToArray();
                if (e.Any())
                    throw new AggregateException(e).Flatten();
            }
        }

        Exception TryStart(IComponent component)
        {
            Contract.Requires<ArgumentNullException>(component != null);
            Trace.TraceInformation("{0}: TryStart ({1})", typeof(ComponentManager).Name, component.GetType().FullName);

            try
            {
                if (IsComponentEnabled(component))
                    component.Start();
                return null;
            }
            catch (Exception e)
            {
                e.Trace();
                return e;
            }
        }

        Exception TryStop(IComponent component)
        {
            Contract.Requires<ArgumentNullException>(component != null);
            Trace.TraceInformation("{0}: TryStop ({1})", typeof(ComponentManager).Name, component.GetType().FullName);

            try
            {
                if (IsComponentEnabled(component))
                    component.Stop();
                return null;
            }
            catch (Exception e)
            {
                e.Trace();
                return e;
            }
        }

        /// <summary>
        /// Returns <c>true</c> if the given <see cref="IComponent"/> is enabled.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        bool IsComponentEnabled(IComponent component)
        {
            Contract.Requires<ArgumentNullException>(component != null);

            if (startTypes.Length == 0)
                return true;

            if (startTypes.Any(i => i == component.GetType()))
                return true;

            return false;
        }

    }

}
