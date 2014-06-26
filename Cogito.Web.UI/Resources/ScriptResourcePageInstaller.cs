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
        string GetResourceNameFromScript(IResource resource)
        {
            Contract.Requires<ArgumentNullException>(resource != null);

            var name = resource.Name;
            if (name.EndsWith(".js"))
                name = name.RemoveEnd(".js");

            return name;
        }

        /// <summary>
        /// Gets the resource name for the given resource.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        string GetResourceName(IResource resource)
        {
            // does the resource specify any specific script resource information?
            var web = resource as IWebScriptResource;
            var src = web != null ? web.ScriptResourceName : GetResourceNameFromScript(resource);

            return src;
        }

        /// <summary>
        /// Gets the resource name for a bundle.
        /// </summary>
        /// <param name="bundle"></param>
        /// <returns></returns>
        string GetBundleName(IResourceBundle bundle)
        {
            var web = bundle as IWebScriptResourceBundle;
            var src = web != null ? web.ScriptResourceName : null;
            if (src == null)
            {
                var scr = bundle.FirstOrDefault(i => i.ContentType == "application/javascript");
                if (scr != null)
                    src = GetResourceName(scr);
            }

            return src;
        }

        /// <summary>
        /// Gets whether or not the resource is a debug resource.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        bool IsDebug(IResource resource)
        {
            return resource.IsDebug ?? false;
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

            // install everything in the bundle
            if (resource.Bundle != null)
                return InstallBundle(page, resource.Bundle);

            var url = ResolveUrl(page, resource);
            if (url == null)
                throw new NullReferenceException(string.Format("Could not resolve Url for resource {0}.", resource));

            // define resource
            var src = GetResourceName(resource);
            var def = new ScriptResourceDefinition();
            def.Path = url;
            ScriptManager.ScriptResourceMapping.AddDefinition(src, null, def);

            // register current script
            ScriptManager.GetCurrent(page).Scripts.Insert(0, new ScriptReference()
            {
                Name = src,
            });

            return true;
        }

        /// <summary>
        /// Installs all the resources in a given bundle.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="bundle"></param>
        /// <returns></returns>
        bool InstallBundle(Page page, IResourceBundle bundle)
        {
            var src = GetBundleName(bundle);
            if (src == null)
                return false;

            var def = GetScriptDefinition(page, bundle);
            if (def == null)
                return false;

            // check for existing mapping
            var map = ScriptManager.ScriptResourceMapping.GetDefinition(src);
            if (map != null &&
                map.Path == def.Path &&
                map.DebugPath == def.DebugPath)
                return true;

            // add the resource mapping, that didn't already exist
            ScriptManager.ScriptResourceMapping.AddDefinition(src, null, def);

            // insert script reference into page
            var lst = ScriptManager.GetCurrent(page).Scripts;
            var pos = lst.Select((i, j) => !(i is ScriptResourceBundleReference) ? j : -1).FirstOrDefault(i => i > -1);
            lst.Insert(pos, new ScriptResourceBundleReference(bundle, src));

            return true;
        }

        /// <summary>
        /// Generates a script definition for the given bundle.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="bundle"></param>
        /// <returns></returns>
        ScriptResourceDefinition GetScriptDefinition(Page page, IResourceBundle bundle)
        {
            var scripts = bundle
                .Where(i => i.ContentType == "application/javascript");

            // script for non-debug mode
            var script = scripts
                .Where(i => !IsDebug(i))
                .FirstOrDefault();

            // script for debug mode
            var debugScript = scripts
                .Where(i => IsDebug(i))
                .FirstOrDefault();

            // generate new definition if paths are available
            if (script != null ||
                debugScript != null)
                return new ScriptResourceDefinition()
                {
                    Path = script != null ? ResolveUrl(page, script) : null,
                    DebugPath = debugScript != null ? ResolveUrl(page, debugScript) : null,
                };

            return null;
        }

    }

}
