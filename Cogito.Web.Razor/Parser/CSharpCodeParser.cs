using System;
using System.Web.Razor.Generator;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Tokenizer.Symbols;

using Cogito.Web.Razor.Generator;

namespace Cogito.Web.Razor.Parser
{

    /// <summary>
    /// Implements an extended version of the <see cref="CSharpCodeParser"/>, supporting some new directives.
    /// </summary>
    public class CSharpCodeParser :
        System.Web.Razor.Parser.CSharpCodeParser
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CSharpCodeParser()
            : base()
        {
            MapDirectives(ImplementsDirective, "implements");
            MapDirectives(AttributeDirective, "attribute");
        }

        /// <summary>
        /// Processes the @attribute directive, which adds a .Net custom attribute declaration to the generated class.
        /// </summary>
        protected virtual void ImplementsDirective()
        {
            AssertDirective("implements");
            AcceptAndMoveNext();
            BaseTypeDirective("implements keyword must be followed by interface name", i =>
                new CSharpImplementsCodeGenerator(i));
        }

        /// <summary>
        /// Processes the @attribute directive, which adds a .Net custom attribute declaration to the generated class.
        /// </summary>
        protected virtual void AttributeDirective()
        {
            AssertDirective("attribute");
            AcceptAndMoveNext();
            AttributeDirectiveCore("attribute keyword must be followed by attribute declaration", i =>
                new CSharpAttributeCodeGenerator(i));
        }

        protected void AttributeDirectiveCore(string noTypeNameError, Func<string, SpanCodeGenerator> createCodeGenerator)
        {
            if (noTypeNameError == null)
                throw new ArgumentNullException(nameof(noTypeNameError));
            if (createCodeGenerator == null)
                throw new ArgumentNullException(nameof(createCodeGenerator));

            // set the block type and position
            Context.CurrentBlock.Type = BlockType.Directive;

            // accept whitespace
            var remainingWs = AcceptSingleWhiteSpaceCharacter();

            if (Span.Symbols.Count > 1)
                Span.EditHandler.AcceptedCharacters = AcceptedCharacters.None;

            Output(SpanKind.MetaCode);

            if (remainingWs != null)
                Accept(remainingWs);

            // accept up until first non-whitespace
            AcceptWhile(IsSpacingToken(includeNewLines: false, includeComments: true));

            // error if we've reached the end of the file
            if (EndOfFile || At(CSharpSymbolType.WhiteSpace) || At(CSharpSymbolType.NewLine))
                Context.OnError(CurrentLocation, noTypeNameError);

            // parse to the end of the line
            AcceptUntil(CSharpSymbolType.NewLine);
            if (!Context.DesignTimeMode)
                Optional(CSharpSymbolType.NewLine);

            // set up code generation
            Span.CodeGenerator = createCodeGenerator(((string)Span.GetContent()).Trim());

            // output the span and finish the block
            CompleteBlock();
            Output(SpanKind.Code);
        }

        /// <summary>
        /// Completes the current block.
        /// </summary>
        void CompleteBlock()
        {
            CompleteBlock(insertMarkerIfNecessary: true);
        }

        /// <summary>
        /// Completes the current block.
        /// </summary>
        /// <param name="insertMarkerIfNecessary"></param>
        void CompleteBlock(bool insertMarkerIfNecessary)
        {
            CompleteBlock(insertMarkerIfNecessary, captureWhitespaceToEndOfLine: insertMarkerIfNecessary);
        }

        /// <summary>
        /// Completes the current block.
        /// </summary>
        /// <param name="insertMarkerIfNecessary"></param>
        /// <param name="captureWhitespaceToEndOfLine"></param>
        void CompleteBlock(bool insertMarkerIfNecessary, bool captureWhitespaceToEndOfLine)
        {
            if (insertMarkerIfNecessary && Context.LastAcceptedCharacters != AcceptedCharacters.Any)
                AddMarkerSymbolIfNecessary();

            EnsureCurrent();

            // Read whitespace, but not newlines
            // If we're not inserting a marker span, we don't need to capture whitespace
            if (!Context.WhiteSpaceIsSignificantToAncestorBlock &&
                Context.CurrentBlock.Type != BlockType.Expression &&
                captureWhitespaceToEndOfLine &&
                !Context.DesignTimeMode &&
                !IsNested)
                CaptureWhitespaceAtEndOfCodeOnlyLine();
            else
                PutCurrentBack();
        }

        /// <summary>
        /// Captures the remaining whitespace for the line.
        /// </summary>
        void CaptureWhitespaceAtEndOfCodeOnlyLine()
        {
            var ws = ReadWhile(sym => sym.Type == CSharpSymbolType.WhiteSpace);
            if (At(CSharpSymbolType.NewLine))
            {
                Accept(ws);
                AcceptAndMoveNext();
                PutCurrentBack();
            }
            else
            {
                PutCurrentBack();
                PutBack(ws);
            }
        }

    }

}
