using System;
using System.Diagnostics.Contracts;

namespace Cogito.Fabric
{

    [ContractClass(typeof(IServiceReference_Contract))]
    public interface IServiceReference
    {

        object Bind(Type serviceInterfaceType);

    }

    [ContractClassFor(typeof(IServiceReference))]
    abstract class IServiceReference_Contract :
        IServiceReference
    {

        public object Bind(Type serviceInterfaceType)
        {
            Contract.Requires<ArgumentNullException>(serviceInterfaceType != null);
            throw new NotImplementedException();
        }

    }

}
