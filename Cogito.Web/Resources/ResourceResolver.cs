using System.ComponentModel.Composition;
using System.Web;
using Cogito.Resources;

namespace Cogito.Web.Resources
{

    [Export(typeof(IUrlResolver))]
    public class ResourceResolver :
        IUrlResolver
    {

        public string ResolveUrl(object target)
        {
            var resource = target as IResource;
            if (resource == null)
                return null;

            var http = HttpContext.Current;
            if (http == null)
                return null;

            return string.Format("{0}/r/{1}/{2}/{3}", http.Request.ApplicationPath, resource.Bundle.Id, resource.Bundle.Version, resource.Name);
        }

    }

}
