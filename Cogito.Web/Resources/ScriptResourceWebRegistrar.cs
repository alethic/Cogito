using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Resources;

namespace Cogito.Web.Resources
{

    public class ScriptResourceWebRegistrar :
        IWebApplicationRegistrar
    {

        readonly IResourceBundleQuery bundles;
        readonly IEnumerable<IUrlResolver> resolvers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolvers"></param>
        public ScriptResourceWebRegistrar(
            IResourceBundleQuery bundles,
            [ImportMany] IEnumerable<IUrlResolver> resolvers)
        {
            this.bundles = bundles;
            this.resolvers = resolvers;
        }

        public void Register()
        {

        }

    }

}
