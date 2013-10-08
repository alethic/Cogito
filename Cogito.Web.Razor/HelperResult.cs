using System;
using System.IO;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Encapsulated result of a helper invocation.
    /// </summary>
    public class HelperResult
    {

        Action<TextWriter> action;

        /// <summary>
        /// Initializes new instance.
        /// </summary>
        public HelperResult(Action<TextWriter> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Writes the result.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteTo(TextWriter writer)
        {
            action(writer);
        }

    }

}
