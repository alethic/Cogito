using System;
using System.Web;

using Cogito.Web;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Registers a module which is invoked on each request. This module configures the per-request composition container.
    /// </summary>
    public class RequestScopeModule : IHttpModule
    {

        System.Web.HttpApplication context;

        HttpContextBase Context
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }

        public void Init(System.Web.HttpApplication context)
        {
            this.context = context;
            this.context.BeginRequest += context_BeginRequest;
            this.context.EndRequest += context_EndRequest;
        }

        void context_BeginRequest(object sender, EventArgs args)
        {
            Context.GetCompositionContext();
        }

        void context_EndRequest(object sender, EventArgs args)
        {

        }

        public void Dispose()
        {
            if (context != null)
            {
                context.EndRequest -= context_EndRequest;
                context.BeginRequest -= context_BeginRequest;
                context = null;
            }
        }

    }

}
