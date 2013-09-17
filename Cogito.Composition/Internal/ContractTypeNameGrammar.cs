using Irony.Parsing;

namespace Cogito.Composition.Internal
{

    /// <summary>
    /// Provides a grammar for parsing a MEF contract type specification.
    /// </summary>
    [Language("ContractTypeName", "1", "MEF Contract Type Name Grammar")]
    internal class ContractTypeNameGrammar : Grammar
    {

        public static class Terms
        {

            public const string identifier = "identifier";
            public const string qualified_identifier = "qualified_identifier";
            public const string type_arg_list = "type_arg_list";
            public const string type_arg_opt = "type_arg_opt";
            public const string type_specifier = "type_specifier";

            public const string DOT = "DOT";
            public const string COMMA = "COMMA";
            public const string LPAREN = "LPAREN";
            public const string RPAREN = "RPAREN";

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ContractTypeNameGrammar()
            : base(true)
        {
            var identifier = TerminalFactory.CreateCSharpIdentifier(Terms.identifier);
            var qualified_identifier = new NonTerminal(Terms.qualified_identifier);
            var type_arg_list = new NonTerminal(Terms.type_arg_list);
            var type_arg_opt = new NonTerminal(Terms.type_arg_opt);
            var type_specifier = new NonTerminal(Terms.type_specifier);

            // symbols
            var DOT = ToTerm(".", Terms.DOT);
            var COMMA = ToTerm(",", Terms.COMMA);
            var LPAREN = ToTerm("(", Terms.LPAREN);
            var RPAREN = ToTerm(")", Terms.RPAREN);

            // rules
            qualified_identifier.Rule = MakePlusRule(qualified_identifier, DOT, identifier);
            type_arg_list.Rule = MakeStarRule(type_arg_list, COMMA, type_specifier);
            type_arg_opt.Rule = Empty | LPAREN + type_arg_list + RPAREN;
            type_specifier.Rule = qualified_identifier + type_arg_opt;

            // configure grammar
            Root = type_specifier;
            MarkPunctuation("(", ")", ".", ",");
        }

    }

}
