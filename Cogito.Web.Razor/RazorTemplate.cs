using System;
using System.IO;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Base <see cref="IRazorTemplate"/> type.
    /// </summary>
    public abstract class RazorTemplate : IRazorTemplate
    {

        /// <summary>
        /// Implementation method filled in by template instance.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Writes the value.
        /// </summary>
        /// <param name="value"></param>
        public abstract void Write(
            object value);

        /// <summary>
        /// Writes the <see cref="IHtmlString"/>.
        /// </summary>
        /// <param name="result"></param>
        public virtual void Write(
            IHtmlString result)
        {
            WriteLiteral((object)result);
        }

        /// <summary>
        /// Writes the value.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public abstract void WriteTo(
            TextWriter writer,
            object value);

        /// <summary>
        /// Writes the <see cref="IHtmlString"/>.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="result"></param>
        public virtual void WriteTo(
            TextWriter writer,
            IHtmlString result)
        {
            WriteLiteralTo(writer, (object)result);
        }

        /// <summary>
        /// Writes the literal object.
        /// </summary>
        /// <param name="value"></param>
        public abstract void WriteLiteral(
            object value);

        /// <summary>
        /// Writes the literal object to the given text writer.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public abstract void WriteLiteralTo(
            TextWriter writer,
            object value);

        /// <summary>
        /// Writes the attribute.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="ltoken"></param>
        /// <param name="rtoken"></param>
        /// <param name="values"></param>
        public abstract void WriteAttribute(
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
        /// <param name="values"></param>
        public abstract void WriteAttributeTo(
            TextWriter writer,
            string attr,
            Tuple<string, int> ltoken,
            Tuple<string, int> rtoken,
            params AttributeValue[] values);

        /// <summary>
        /// Gets the layout.
        /// </summary>
        public virtual object Layout
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Defines a section.
        /// </summary>
        public virtual void DefineSection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a new context.
        /// </summary>
        public virtual void BeginContext()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ends a context.
        /// </summary>
        public virtual void EndContext()
        {
            throw new NotImplementedException();
        }

    }

}
