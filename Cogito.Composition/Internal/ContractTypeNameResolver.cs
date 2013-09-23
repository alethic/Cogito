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
            return null;

            //var p = parser.Parse(contractName);
            //if (p.HasErrors())
            //    throw new AggregateException(p.ParserMessages.Where(i => i.Level == Irony.ErrorLevel.Error).Select(i => new Exception(i.Message)));

            //var type_specifier = p.Root;
            //if (type_specifier == null)
            //    throw new Exception("No type_specifier.");

            //var qualified

            //var type_arg_opt = p.Root.ChildNodes.FirstOrDefault(i => i.Term.Name == ContractTypeNameGrammar.Terms.type_arg_opt);
            //if (type_arg_opt)

            //return t.ToType();
        }

    }

}
