using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Encapsulated result of a helper invocation.
    /// </summary>
    public class HelperResult : IHtmlString
    {

        readonly Action<TextWriter> action;

        /// <summary>
        /// Initializes new instance.
        /// </summary>
        public HelperResult(Action<TextWriter> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            this.action = action;
        }

        /// <summary>
        /// Writes the result.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteTo(TextWriter writer)
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            action(writer);
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="HelperResult"/>.
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            using (var wrt = new StringWriter(CultureInfo.InvariantCulture))
            {
                WriteTo(wrt);
                return wrt.ToString();
            }
        }

        public override string ToString()
        {
            return ToHtmlString();
        }

    }

}
