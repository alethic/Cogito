using System.Web.Razor;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Specialied <see cref="RazorEngineHost"/>.
    /// </summary>
    public class RazorHost : RazorEngineHost
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="codeLanguage"></param>
        public RazorHost()
            : base(new CSharpRazorCodeLanguage())
        {

        }

    }

}
