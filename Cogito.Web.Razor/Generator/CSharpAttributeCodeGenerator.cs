using System;
using System.CodeDom;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Razor.Generator;
using System.Web.Razor.Parser.SyntaxTree;

using Cogito.Irony;

namespace Cogito.Web.Razor.Generator
{

    /// <summary>
    /// Sets the base type from the @attribute directive.
    /// </summary>
    public class CSharpAttributeCodeGenerator : SpanCodeGenerator
    {

        readonly string signature;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="modelType"></param>
        public CSharpAttributeCodeGenerator(string signature)
            : base()
        {
            Contract.Requires<ArgumentNullException>(signature != null);

            this.signature = signature;
        }

        public override void GenerateCode(Span target, CodeGeneratorContext context)
        {
            // will be parsing this code
            var code = target.Content.Trim();

            // parse the attribute declaration code
            var p = new global::Irony.Parsing.Parser(new CSharpAttributeDeclarationGrammar()).Parse(code);
            p.ThrowParseErrors();

            // extract attribute name
            var attributeName = p
                .Node("attribute")
                .Node("qual_name_with_targs")
                .SpanText(code);

            // extract attribute args
            var attributeArgs = p
                .Node("attribute")
                .Node("attribute_arguments_par_opt")
                .Node("attribute_arguments")
                .Nodes("attr_arg")
                .Select(i => i.SpanText(code))
                .ToList();

            // custom attribute declaration, using a code snippet expression
            context.GeneratedClass.CustomAttributes.Add(new CodeAttributeDeclaration(
                attributeName,
                attributeArgs
                    .Select(i => new CodeAttributeArgument(new CodeSnippetExpression(i)))
                    .ToArray()));
        }

    }

}
