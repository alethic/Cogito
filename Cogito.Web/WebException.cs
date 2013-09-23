using Cogito.Application;

namespace Cogito.Web
{


    public class WebException : ModuleException<IWebModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebException(IWebModule module)
            : base(module)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebException(IWebModule module, string message)
            : base(module)
        {

        }

    }


}
