using System;
using System.Web;
using System.Linq;
using Cogito.Resources;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(Cogito.Web.Resources.ResourceModule), "Start")]

namespace Cogito.Web.Resources
{

    /// <summary>
    /// Provides a container entry point for web requests.
    /// </summary>
    public class ResourceModule :
        IHttpModule
    {

        /// <summary>
        /// Registers the web http module.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(ResourceModule));
        }

        /// <summary>
        /// Initializes the module.
        /// </summary>
        /// <param name="context"></param>
        public void Init(System.Web.HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        /// <summary>
        /// Invoked when a request begins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void context_BeginRequest(object sender, EventArgs args)
        {
            var http = HttpContext.Current;
            if (http == null)
                return;

            if (http.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/r/"))
            {
                var a = http.Request.AppRelativeCurrentExecutionFilePath.Split('/');
                if (a.Length < 5)
                    return;

                var c = WebContainerManager.GetDefaultContainer();
                if (c == null)
                    throw new NullReferenceException("Could not locate Container.");

                var q = c.GetExportedValue<IResourceQuery>();
                if (q == null)
                    throw new NullReferenceException();

                // extract resource identity
                var bundleId = a[2];
                var version = a[3];
                var name = string.Join("/", a, 4, a.Length - 4);

                // search for matching resource
                var r = q
                    .Where(i => i.Bundle.Id == bundleId)
                    .Where(i => i.Bundle.Version.ToString().Equals(version))
                    .Where(i => i.Name == name)
                    .FirstOrDefault();
                if (r == null)
                {
                    http.Response.StatusCode = 404;
                    http.Response.End();
                    return;
                }

                // obtain file stream
                var s = r.Source() as Stream;
                if (s == null)
                    return;

                // set output length if possible
                if (s.CanSeek && s.Length > 0)
                    http.Response.AddHeader("Content-Length", s.Length.ToString());

                // output file and exit
                s.CopyTo(http.Response.OutputStream);
                http.Response.StatusCode = 200;
                http.Response.ContentType = r.ContentType;
                http.Response.End();
            }
        }

        /// <summary>
        /// Invoked when a request ends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void context_EndRequest(object sender, EventArgs args)
        {

        }

        /// <summary>
        /// Disposes of the module.
        /// </summary>
        public void Dispose()
        {

        }

    }

}
