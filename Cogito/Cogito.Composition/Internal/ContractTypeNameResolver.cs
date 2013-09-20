using System;
using Irony.Parsing;

namespace Cogito.Composition.Internal
{

    /// <summary>
    /// Provides a method to resolve a <see cref="Type"/> from a MEF contract name specification.
    /// </summary>
    static class ContractTypeNameResolver
    {

        /// <summary>
        /// Irony parser for contract name.
        /// </summary>
        static readonly Parser parser = new Parser(new ContractTypeNameGrammar());

        /// <summary>
        /// Attempts to resolve the type specified by <paramref name="contractName"/>.
        /// </summary>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public static Type ResolveType(string contractName)
        {
            var p = parser.Parse(contractName);
            var x = p.ToXml();
            return null;
        }

    }

}
