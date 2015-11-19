using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Components
{

    /// <summary>
    /// Provides <see cref="IComponent"/> instances.
    /// </summary>
    [ContractClass(typeof(IComponentProvider_Contract))]
    public interface IComponentProvider
    {

        /// <summary>
        /// Gets the <see cref="IComponent"/> instances.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IComponent> Components { get; }

    }

    [ContractClassFor(typeof(IComponentProvider))]
    abstract class IComponentProvider_Contract :
        IComponentProvider
    {

        public IEnumerable<IComponent> Components
        {
            get { Contract.Ensures(Contract.Result<IEnumerable<IComponent>>() != null); throw new NotImplementedException(); }
        }

    }

}
