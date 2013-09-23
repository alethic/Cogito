using Cogito.Application;

namespace Cogito.Web.Http
{

    public class WebApiException : ModuleException<IWebApiModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebApiException(IWebApiModule module)
            : base(module)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebApiException(IWebApiModule module, string message)
            : base(module)
        {

        }

    }


}
