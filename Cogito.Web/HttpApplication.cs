using System;
using System.Web;

using Cogito.Composition.Hosting;

namespace Cogito.Web
{

    /// <summary>
    /// Base <see cref="HttpApplication"/> implementation for the Web container framework. Ensures the container is
    /// initialized and that the Start phase is executed.
    /// </summary>
    public class HttpApplication :
        System.Web.HttpApplication
    {

        readonly Lazy<Ref<CompositionContainer>> composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpApplication()
        {
            this.composition = new Lazy<Ref<CompositionContainer>>(() => 
                ContainerManager.GetDefaultContainer().GetExportedValue<Func<Ref<CompositionContainer>>>()());
        }

        /// <summary>
        /// Gets a reference to the <see cref="CompositionContainer"/> for the application.
        /// </summary>
        public CompositionContainer Container
        {
            get { return composition.Value.Value; }
        }

        /// <summary>
        /// Invoked when the application is started.
        /// </summary>
        public void Application_Start()
        {
            OnStart();
        }

        /// <summary>
        /// Invoked when the application is started.
        /// </summary>
        protected virtual void OnStart()
        {

        }

        /// <summary>
        /// Invoked when the application is stopped.
        /// </summary>
        public void Application_Stop()
        {
            OnStop();
        }

        /// <summary>
        /// Invoked when the application is stopped.
        /// </summary>
        protected virtual void OnStop()
        {
            if (composition.IsValueCreated)
                composition.Value.Dispose();
        }

        /// <summary>
        /// Invoked when an unhandled exception occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Application_Error(object sender, EventArgs args)
        {
            var e = Server.GetLastError();
            if (e == null)
                return;

            // log error
            e.Trace();

            // save error away for next page
            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null)
                HttpContext.Current.Session["LastError"] = e;

            OnError(e);
        }

        /// <summary>
        /// Invoked when an unhandled exception occurs.
        /// </summary>
        protected virtual void OnError(Exception e)
        {

        }

        /// <summary>
        /// Invoked when a request begins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Application_BeginRequest(object sender, EventArgs args)
        {
            OnBeginRequest();
        }

        /// <summary>
        /// Invoked when a request begins.
        /// </summary>
        protected virtual void OnBeginRequest()
        {

        }

        /// <summary>
        /// Invoked when a request is authenticated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            OnAuthenticateRequest();
        }

        /// <summary>
        /// Invoked when a request is authenticated.
        /// </summary>
        protected virtual void OnAuthenticateRequest()
        {

        }

        /// <summary>
        /// Invoked when a request ends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Application_EndRequest(object sender, EventArgs args)
        {
            OnEndRequest();
        }

        /// <summary>
        /// Invoked when a request ends.
        /// </summary>
        protected virtual void OnEndRequest()
        {

        }

        /// <summary>
        /// Invoked when a session begins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Session_Start(object sender, EventArgs args)
        {
            OnSessionStart();
        }

        /// <summary>
        /// Invoked when a session begins.
        /// </summary>
        protected virtual void OnSessionStart()
        {

        }

    }

}
