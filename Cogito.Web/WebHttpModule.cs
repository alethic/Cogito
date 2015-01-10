using System;
using System.Web;

using Cogito.Collections;
using Cogito.Composition.Hosting;
using Cogito.Web.Infrastructure;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: PreApplicationStartMethod(typeof(Cogito.Web.WebHttpModule), "Start")]

namespace Cogito.Web
{

    /// <summary>
    /// Provides a container entry point for web requests.
    /// </summary>
    public class WebHttpModule :
        IHttpModule
    {

        /// <summary>
        /// Registers the web http module.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(WebHttpModule));
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

        }

        /// <summary>
        /// Invoked when a request ends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void context_EndRequest(object sender, EventArgs args)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                // find existing item
                var r = ctx.Items.GetOrDefault(WebRequestScopeProvider.CONTEXT_KEY) as Ref<CompositionContainer>;
                if (r != null)
                {
                    ctx.Items.Remove(WebRequestScopeProvider.CONTEXT_KEY);
                    r.Dispose();
                }
            }
        }

        /// <summary>
        /// Disposes of the module.
        /// </summary>
        public void Dispose()
        {

        }

    }

}
