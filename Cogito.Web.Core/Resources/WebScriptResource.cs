using System;
using System.Diagnostics.Contracts;

using Cogito.Resources;

namespace Cogito.Web.Resources
{

    /// <summary>
    /// Describes a script resource.
    /// </summary>
    public class WebScriptResource :
        Resource,
        IWebScriptResource
    {

        readonly string scriptResourceName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="source"></param>
        /// <param name="scriptResourceName"></param>
        /// <param name="isDebug"></param>
        public WebScriptResource(
            IResourceBundle bundle,
            string name,
            string scriptResourceName,
            Func<object> source,
            string contentType = "application/javascript",
            bool isDebug = false)
            : base(
                bundle,
                name,
                contentType,
                source,
                isDebug: isDebug)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(scriptResourceName != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);

            this.scriptResourceName = scriptResourceName;
        }


        public string ScriptResourceName
        {
            get { return scriptResourceName; }
        }

    }

}
