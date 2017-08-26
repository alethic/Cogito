using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Cogito.Components
{

    /// <summary>
    /// Provides <see cref="IComponent"/> instances exported by the container.
    /// </summary>
    [Export(typeof(IComponentProvider))]
    public class DefaultComponentProvider :
        IComponentProvider
    {

        readonly IEnumerable<IComponent> components;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="components"></param>
        [ImportingConstructor]
        public DefaultComponentProvider(
            [ImportMany] IEnumerable<IComponent> components)
        {
            this.components = components ?? throw new ArgumentNullException(nameof(components));
        }

        public IEnumerable<IComponent> Components
        {
            get { return components; }
        }

    }

}
