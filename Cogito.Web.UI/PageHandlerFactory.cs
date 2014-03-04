using System.Web;

namespace Cogito.Web.UI
{

    public class PageHandlerFactory : 
        System.Web.UI.PageHandlerFactory
    {

        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            return base.GetHandler(context, requestType, virtualPath, path);
        }

    }

}
