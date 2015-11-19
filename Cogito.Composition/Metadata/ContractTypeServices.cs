using System;
using System.Diagnostics.Contracts;

using Cogito.Composition.Internal;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Provides services for working with contract names specified by <see cref="Type"/>.
    /// </summary>
    public static class ContractTypeServices
    {

        /// <summary>
        /// Attempts to resolve a contract name into a <see cref="Type"/>.
        /// </summary>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public static Type ResolveContractName(string contractName)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));

            return ContractTypeNameResolver.ResolveType(contractName);
        }

    }

}
