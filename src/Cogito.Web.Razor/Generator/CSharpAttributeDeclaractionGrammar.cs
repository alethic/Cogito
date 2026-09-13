using Irony.Parsing;

namespace Cogito.Web.Razor.Generator
{

    /// <summary>
    /// Partial CSharp grammar for attribute declarations.
    /// </summary>
    [Language("AttributeDeclaration", "1", "Razor Attribute Declaration Grammar")]
    class CSharpAttributeDeclarationGrammar : CSharpGrammar
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CSharpAttributeDeclarationGrammar()
            : base()
        {
            Root = attribute;
        }

    }

}
