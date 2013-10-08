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
        /// Writes the <see cref="HelperResult"/>.
        /// </summary>
        /// <param name="result"></param>
        void Write(
            HelperResult result);

        /// <summary>
        /// Writes the value.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        void WriteTo(
            TextWriter writer,
            object value);

        /// <summary>
        /// Writes the <see cref="HelperResult"/>.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="result"></param>
        void WriteTo(
            TextWriter writer,
            HelperResult result);

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
        /// Gets the layout.
        /// </summary>
        object Layout { get; }

        /// <summary>
        /// Defines a section.
        /// </summary>
        void DefineSection();

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
