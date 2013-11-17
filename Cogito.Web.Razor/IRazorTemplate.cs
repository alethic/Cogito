using System;
using System.IO;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Describes the methods available for a Razor template implementation.
    /// </summary>
    public interface IRazorTemplate
    {

        /// <summary>
        /// Executes the template.
        /// </summary>
        void Execute();

        /// <summary>
        /// Writes the value.
        /// </summary>
        /// <param name="value"></param>
        void Write(
            object value);

        /// <summary>
        /// Writes the <see cref="IHtmlString"/>.
        /// </summary>
        /// <param name="html"></param>
        void Write(
            IHtmlString html);

        /// <summary>
        /// Writes the value.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        void WriteTo(
            TextWriter writer,
            object value);

        /// <summary>
        /// Writes the <see cref="IHtmlString"/>.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="html"></param>
        void WriteTo(
            TextWriter writer,
            IHtmlString html);

        /// <summary>
        /// Writes the literal value.
        /// </summary>
        /// <param name="value"></param>
        void WriteLiteral(
            object value);

        /// <summary>
        /// Writes the literal value.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        void WriteLiteralTo(
            TextWriter writer,
            object value);

        /// <summary>
        /// Writes the attribute.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="ltoken"></param>
        /// <param name="rtoken"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        void WriteAttribute(
            string attr,
            Tuple<string, int> ltoken,
            Tuple<string, int> rtoken,
            params AttributeValue[] values);

        /// <summary>
        /// Writes the attribute.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="attr"></param>
        /// <param name="ltoken"></param>
        /// <param name="rtoken"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        void WriteAttributeTo(
            TextWriter writer,
            string attr,
            Tuple<string, int> ltoken,
            Tuple<string, int> rtoken,
            params AttributeValue[] values);

        /// <summary>
        /// Renders the body.
        /// </summary>
        /// <returns></returns>
        object RenderBody();

        /// <summary>
        /// Returns <c>true</c> if the specified section is defined.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        bool IsSectionDefined(string sectionName);

        /// <summary>
        /// Defines a section.
        /// </summary>
        void DefineSection(string sectionName, Action action);

        /// <summary>
        /// Renders a section.
        /// </summary>
        /// <param name="sectionName"></param>
        object RenderSection(string sectionName);

        /// <summary>
        /// Renders a section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="required"></param>
        object RenderSection(string sectionName, bool required);

        /// <summary>
        /// Begins a context.
        /// </summary>
        void BeginContext();

        /// <summary>
        /// Ends a context.
        /// </summary>
        void EndContext();

    }

}
