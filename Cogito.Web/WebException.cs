using System;
using System.Diagnostics.Contracts;

using Cogito.Application;

namespace Cogito.Web
{


    public class WebException :
        ModuleException<IWebModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebException(IWebModule module)
            : base(module)
        {
            Contract.Requires<ArgumentNullException>(module != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public WebException(IWebModule module, string message)
            : base(module)
        {
            Contract.Requires<ArgumentNullException>(module != null);
        }

    }


}
