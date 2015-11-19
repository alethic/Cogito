using System.Web;
using Nancy;

namespace Cogito.Nancy.Web.UI.Tests.Site
{

    [NancyModule]
    public class PageTestModule :
        NancyModule
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public PageTestModule()
            : base("test")
        {
            Get["/{Name}"] = x => PageGet((string)x.Name);
        }

        dynamic PageGet(string name)
        {
            var factory = new NancyPageHandlerFactory();
            var page = factory.GetHandler(HttpContext.Current, "GET", "~/Test.aspx", HttpContext.Current.Server.MapPath("~/Test.aspx"));
            page.ProcessRequest(HttpContext.Current);
            return null;
        }

    }

}