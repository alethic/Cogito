using Cogito.Application.Lifecycle;
using Cogito.Composition;
using Cogito.Composition.Hosting.Configuration;

namespace Cogito.Web
{

    /// <summary>
    /// Base <see cref="HttpApplication"/> implementation for the Web container framework. Ensures the container is
    /// initialized and that the Start phase is executed.
    /// </summary>
    public class HttpApplication : System.Web.HttpApplication
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpApplication()
            : this("Default")
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="containerName"></param>
        public HttpApplication(string containerName)
            : this(ConfigurationManager.GetContainer(containerName))
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public HttpApplication(System.ComponentModel.Composition.Hosting.CompositionContainer container)
            : this(container.AsContext())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        public HttpApplication(ICompositionContext composition)
            : base()
        {
            this.composition = composition;
        }

        public ICompositionContext Composition
        {
            get { return this.composition; }
        }

        protected virtual void OnStart()
        {
            composition.GetExportedValue<ILifecycleManager<IWebModule>>()
                .Start();
        }

    }

}
