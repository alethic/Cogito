using System.Web.Razor.Generator;
using System.Web.Razor.Parser.SyntaxTree;

namespace Cogito.Web.Razor.Generator
{

    /// <summary>
    /// Sets the base type from the @implements directive.
    /// </summary>
    public class CSharpImplementsCodeGenerator : SpanCodeGenerator
    {

        string interfaceName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="interfaceName"></param>
        public CSharpImplementsCodeGenerator(string interfaceName)
            : base()
        {
            this.interfaceName = interfaceName;
        }

        public override void GenerateCode(Span target, CodeGeneratorContext context)
        {
            context.GeneratedClass.BaseTypes.Add(interfaceName);
        }

    }

}
