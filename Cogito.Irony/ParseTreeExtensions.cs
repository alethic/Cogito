using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

using Irony;
using Irony.Parsing;

namespace Cogito.Irony
{

    /// <summary>
    /// Provides extension methods for working with an Irony <see cref="ParseTree"/>.
    /// </summary>
    public static class ParseTreeExtensions
    {

        /// <summary>
        /// Throws any parse errors as an exception.
        /// </summary>
        /// <param name="parseTree"></param>
        public static void ThrowParseErrors(this ParseTree parseTree)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);

            if (parseTree.HasErrors())
                throw new AggregateException(parseTree.ParserMessages
                    .Where(i => i.Level == ErrorLevel.Error)
                    .Select(i => new ParseException(i)));
        }

        /// <summary>
        /// Converts the <see cref="ParseTree"/> into a <see cref="XDocument"/>.
        /// </summary>
        /// <param name="parseTree"></param>
        /// <returns></returns>
        public static XDocument ToXDocument(this ParseTree parseTree)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root != null);

            return new XDocument(
                ToXElement(parseTree.Root));
        }

        /// <summary>
        /// Converts the <see cref="ParseTreeNode"/> into an <see cref="XElement"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static XElement ToXElement(this ParseTreeNode node)
        {
            Contract.Requires<ArgumentNullException>(node != null);
            Contract.Requires<ArgumentNullException>(node.Term != null);

            return new XElement("Node",
                new XAttribute("Term", node.Term.Name),
                node.Term.HasAstConfig() && node.Term.AstConfig.NodeType != null ? new XAttribute("AstNodeType", node.Term.AstConfig.NodeType.Name) : null,
                new XAttribute("Line", node.Span.Location.Line),
                new XAttribute("Column", node.Span.Location.Column),
                new XAttribute("Position", node.Span.Location.Position),
                new XAttribute("Length", node.Span.Length),
                node.Token != null ? new XAttribute("Terminal", node.Term.GetType().Name) : null,
                node.Token != null && node.Token.Value != null ? new XAttribute("Value", node.Token.Value) : null,
                node.ChildNodes.Select(i => ToXElement(i)));
        }

        /// <summary>
        /// Gets the first child <see cref="ParseTreeNode"/> with the specified name.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ParseTreeNode Node(this ParseTreeNode node, string name)
        {
            Contract.Requires<ArgumentNullException>(node != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return node.ChildNodes.Find(i => i.Term.Name == name);
        }

        /// <summary>
        /// Gets the first child <see cref="ParseTreeNode"/> with the specfied name.
        /// </summary>
        /// <param name="parseTree"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ParseTreeNode Node(this ParseTree parseTree, string name)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return parseTree.Root.Term.Name == name ? parseTree.Root : null;
        }

        /// <summary>
        /// Gets the first child <see cref="ParseTreeNode"/> with the specified <see cref="BnfTerm"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ParseTreeNode Node(this ParseTreeNode node, BnfTerm term)
        {
            Contract.Requires<ArgumentNullException>(node != null);
            Contract.Requires<ArgumentNullException>(term != null);

            return node.ChildNodes.Find(i => i.Term == term);
        }

        /// <summary>
        /// Gets the first child <see cref="ParseTreeNode"/> with the specfied <see cref="BnfTerm"/>.
        /// </summary>
        /// <param name="parseTree"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ParseTreeNode Node(this ParseTree parseTree, BnfTerm term)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);
            Contract.Requires<ArgumentNullException>(term != null);

            return parseTree.Root.Term == term ? parseTree.Root : null;
        }

        /// <summary>
        /// Gets the child elements <see cref="ParseTreeNode"/> with the specified name.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<ParseTreeNode> Nodes(this ParseTreeNode node, string name)
        {
            Contract.Requires<ArgumentNullException>(node != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return node.ChildNodes.Where(i => i.Term.Name == name);
        }

        /// <summary>
        /// Gets the child elements <see cref="ParseTreeNode"/> with the specified name.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<ParseTreeNode> Nodes(this ParseTree parseTree, string name)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root.Term != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root.Term.Name != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return parseTree.Root.Term.Name == name ? new[] { parseTree.Root } : Enumerable.Empty<ParseTreeNode>();
        }

        /// <summary>
        /// Gets the child elements <see cref="ParseTreeNode"/> with the specified <see cref="BnfTerm"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static IEnumerable<ParseTreeNode> Nodes(this ParseTreeNode node, BnfTerm term)
        {
            Contract.Requires<ArgumentNullException>(node != null);
            Contract.Requires<ArgumentNullException>(term != null);

            return node.ChildNodes.Where(i => i.Term == term);
        }

        /// <summary>
        /// Gets the child elements <see cref="ParseTreeNode"/> with the specified <see cref="BnfTerm"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<ParseTreeNode> Nodes(this ParseTree parseTree, BnfTerm term)
        {
            Contract.Requires<ArgumentNullException>(parseTree != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root != null);
            Contract.Requires<ArgumentNullException>(parseTree.Root.Term != null);
            Contract.Requires<ArgumentNullException>(term != null);

            return parseTree.Root.Term == term ? new[] { parseTree.Root } : Enumerable.Empty<ParseTreeNode>();
        }

        /// <summary>
        /// Gets the text spanned by the <see cref="ParseTreeNode"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SpanText(this ParseTreeNode node, string source)
        {
            Contract.Requires<ArgumentNullException>(node != null, "node");
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Requires<ArgumentOutOfRangeException>(source.Length >= node.Span.Location.Position + node.Span.Length, "source");

            return source.Substring(node.Span.Location.Position, node.Span.Length);
        }

    }

}
