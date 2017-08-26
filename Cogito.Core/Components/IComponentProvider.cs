using System.Collections.Generic;

namespace Cogito.Components
{

    /// <summary>
    /// Provides <see cref="IComponent"/> instances.
    /// </summary>
    public interface IComponentProvider
    {

        /// <summary>
        /// Gets the <see cref="IComponent"/> instances.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IComponent> Components { get; }

    }

}
