using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the results of the contract name regular expression.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static Type ResolveTypeMatch(Match m)
        {
            throw new NotImplementedException();
        }

    }

}
