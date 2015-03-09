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

        readonly IEnumerable<IComponent> services;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="components"></param>
        [ImportingConstructor]
        public ComponentManager(
            [ImportMany] IEnumerable<IComponent> components)
        {
            Contract.Requires<ArgumentNullException>(components != null);

            this.services = components;
        }

        public void Start()
        {
            lock (services)
            {
                var e = services.Select(i => TryStart(i)).Where(i => i != null).ToArray();
                if (e.Any())
                    throw new AggregateException(e).Flatten();
            }
        }

        public void Stop()
        {
            lock (services)
            {
                var e = services.Select(i => TryStop(i)).Where(i => i != null).ToArray();
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
                component.Stop();
                return null;
            }
            catch (Exception e)
            {
                e.Trace();
                return e;
            }
        }

    }

    /// <summary>
    /// Manages the lifecycle of <see cref="IComponent{TIdentity}"/> instances.
    /// </summary>
    /// <typeparam name="TIdentity"></typeparam>
    public class ComponentManager<TIdentity> :
        ComponentManager,
        IComponentManager<TIdentity>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="components"></param>
        [ImportingConstructor]
        public ComponentManager(
            [ImportMany] IEnumerable<IComponent<TIdentity>> components)
            : base(components)
        {
            Contract.Requires<ArgumentNullException>(components != null);
        }

    }

}
