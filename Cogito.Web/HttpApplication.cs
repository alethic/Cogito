using System;
using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Application.Lifecycle;
using Cogito.Composition;
using Cogito.Composition.Hosting;

namespace Cogito.Web
{

    /// <summary>
    /// Base <see cref="HttpApplication"/> implementation for the Web container framework. Ensures the container is
    /// initialized and that the Start phase is executed.
    /// </summary>
    public class HttpApplication : System.Web.HttpApplication
    {

        readonly ICompositionContext compositionContext;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpApplication()
            : this(ContainerManager.GetDefaultContainer())
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
        public HttpApplication(ICompositionContext composition)
            : base()
        {
            Contract.Requires<ArgumentNullException>(composition != null);

            this.compositionContext = composition;
        }

        /// <summary>
        /// Obtains a reference to the configured <see cref="ICompositionContext"/>.
        /// </summary>
        public ICompositionContext ApplicationCompositionContext
        {
            get { return compositionContext; }
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
            // are we operating in a request?
            var ctx = HttpContext.Current;
            if (ctx == null)
                return null;

            // find existing context
            var com = (ICompositionContext)ctx.Items[typeof(ICompositionContext)];
            if (com != null)
                return com;

            // default to application level
            return compositionContext;
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
        public virtual void OnStart()
        {
            compositionContext.GetExportedValue<ILifecycleManager<IWebModule>>()
                .Start();
        }

    }

}
