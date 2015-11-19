using System;
using System.Diagnostics.Contracts;

using Cogito.Application;

namespace Cogito.Web.Http
{

    public class WebApiException :
        ModuleException<IWebApiModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebApiException(IWebApiModule module)
            : base(module)
        {
            Contract.Requires<ArgumentNullException>(module != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebApiException(IWebApiModule module, string message)
            : base(module)
        {
            Contract.Requires<ArgumentNullException>(module != null);
        }

    }


}
