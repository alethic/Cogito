using System.Web;

namespace Cogito.Web.UI.Resources
{

    public class ResourceHttpHandler :
        IHttpHandler
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ResourceHttpHandler()
        {

        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

        }

    }

}
