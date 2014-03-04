using System;
using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Application.Lifecycle;
using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Web
{

    /// <summary>
    /// Base <see cref="HttpApplication"/> implementation for the Web container framework. Ensures the container is
    /// initialized and that the Start phase is executed.
    /// </summary>
    public class HttpApplication :
        System.Web.HttpApplication
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpApplication()
            : this(WebContainerManager.GetDefaultContainer())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="containerName"></param>
        public HttpApplication(string containerName)
            : this(ContainerManager.GetContainer(containerName))
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(containerName));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public HttpApplication(System.ComponentModel.Composition.Hosting.CompositionContainer container)
            : this(container.AsContext())
        {
            Contract.Requires<ArgumentNullException>(container != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        public HttpApplication(
            ICompositionContext composition)
            : base()
        {
            Contract.Requires<ArgumentNullException>(composition != null);

            this.composition = composition;
            this.composition.GetExportedValue<ScopeManager>()
                .RegisterContext(typeof(IRootScope), composition);
        }

        /// <summary>
        /// Obtains a reference to the configured <see cref="ICompositionContext"/>.
        /// </summary>
        public ICompositionContext ApplicationCompositionContext
        {
            get { return composition; }
        }

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> configured for the current request.
        /// </summary>
        public ICompositionContext RequestCompositionContext
        {
            get { return GetRequestCompositionContext(); }
        }

        /// <summary>
        /// Implements the getter for RequestCompositionContext.
        /// </summary>
        /// <returns></returns>
        ICompositionContext GetRequestCompositionContext()
        {
            return composition.GetOrBeginScope<IWebRequestScope>();
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
            composition.GetExportedValue<ILifecycleManager<IWebModule>>().Start();
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected virtual void OnSessionStart()
        {

        }

    }

}
