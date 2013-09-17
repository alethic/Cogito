using System;
using System.Text.RegularExpressions;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Provides services for working with contract names specified by <see cref="Type"/>.
    /// </summary>
    public static class ContractTypeServices
    {

        static readonly Regex contractNameRegex = new Regex(@"^(?:[^()]|(?<Open>[(])|(?<Content-Open>[)]))*(?(Open)(?!))$", RegexOptions.IgnorePatternWhitespace);

        /// <summary>
        /// Attempts to resolve a contract name into a <see cref="Type"/>.
        /// </summary>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public static Type ResolveContractName(string contractName)
        {
            var m = contractNameRegex.Match(contractName);
            if (m.Success)
                return ResolveTypeMatch(m);

            return null;
        }

        /// <summary>
        /// Handles the results of the contract name regular expression.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static Type ResolveTypeMatch(Match m)
        {
            return null;
        }

    }

}
