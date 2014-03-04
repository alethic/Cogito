using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.UI;

using Cogito.Resources;
using Cogito.Web.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Injects referenced scripts into the HTML head section.
    /// </summary>
    [Export(typeof(IResourceReferencePageInstaller))]
    public class ScriptResourcePageInstaller :
        IResourceReferencePageInstaller
    {

        readonly IEnumerable<IUrlResolver> resolvers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolvers"></param>
        [ImportingConstructor]
        public ScriptResourcePageInstaller(
            [ImportMany] IEnumerable<IUrlResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        /// <summary>
        /// Resolves the URL to reach the target object.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        string ResolveUrl(Page page, object target)
        {
            if (target is string)
                return page.ResolveUrl((string)target);

            // find first resolved url to target
            return resolvers
                .Select(i => i.ResolveUrl(target))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the script resource name.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        string GetResourceName(IResource resource)
        {
            Contract.Requires<ArgumentNullException>(resource != null);

            var name = resource.Name;
            if (name.EndsWith(".js"))
                name = name.RemoveEnd(".js");

            return name;
        }

        /// <summary>
        /// Installs the resource into the page.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public bool Install(Page page, IResource resource)
        {
            Contract.Requires<ArgumentNullException>(page != null);
            Contract.Requires<ArgumentNullException>(resource != null);

            if (resource.ContentType != "application/javascript")
                return false;

            var url = ResolveUrl(page, resource);
            if (url == null)
                throw new NullReferenceException(string.Format("Could not resolve Url for resource {0}.", resource));

            // does the resource specify any specific script resource information?
            var web = resource as IWebScriptResource;
            var src = web != null ? web.ScriptResourceName : GetResourceName(resource);

            // define resource
            var def = new ScriptResourceDefinition();
            def.Path = url;
            ScriptManager.ScriptResourceMapping.AddDefinition(src, null, def);

            // register current script
            ScriptManager.GetCurrent(page).Scripts.Add(new ScriptReference()
            {
                Name = src,
            });

            return true;
        }

    }

}
