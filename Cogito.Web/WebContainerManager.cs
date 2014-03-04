using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Web.Configuration;

using mef = System.ComponentModel.Composition.Hosting;

namespace Cogito.Web
{

    /// <summary>
    /// Provides methods for obtaining or configuring web composition scopes.
    /// </summary>
    public static class WebContainerManager
    {

        static readonly object REQUEST_SCOPE_KEY = typeof(ICompositionContext);
        static readonly string APPLICATION_SCOPE_KEY = typeof(ICompositionContext).FullName;

        /// <summary>
        /// Gets the default configured web container.
        /// </summary>
        public static mef.CompositionContainer GetDefaultContainer()
        {
            // web configuration is set to use a specified container
            var containerName = ConfigurationSection.GetDefaultSection().Composition.ContainerName.TrimOrNull();
            if (containerName != null)
                return ContainerManager.GetContainer(containerName);

            // fall back to default container
            return ContainerManager.GetDefaultContainer();
        }

        /// <summary>
        /// Gets the current application scope.
        /// </summary>
        /// <returns></returns>
        public static ICompositionContext GetApplicationScope()
        {
            var http = HttpContext.Current;
            if (http != null)
            {
                var reference = (IDisposable<ICompositionContext>)http.Application.Get(APPLICATION_SCOPE_KEY);
                if (reference != null)
                    return reference.Resource;
            }

            return null;
        }

        /// <summary>
        /// Registers the given root scope with the web application.
        /// </summary>
        /// <param name="composition"></param>
        public static void RegisterApplicationScope(ICompositionContext composition)
        {
            var http = HttpContext.Current;
            if (http != null)
            {
                if (http.Application.Get(APPLICATION_SCOPE_KEY) != null)
                    return;

                // store in context and increase the reference count
                http.Application.Set(APPLICATION_SCOPE_KEY, composition.AsReference());
            }
        }

        /// <summary>
        /// Unregisters the reference to the request scope.
        /// </summary>
        /// <param name="composition"></param>
        public static void UnregisterApplicationScope()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                var app = (IDisposable<ICompositionContext>)ctx.Application.Get(APPLICATION_SCOPE_KEY);
                if (app != null)
                {
                    ctx.Items.Remove(APPLICATION_SCOPE_KEY);
                    app.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets or creates and registers the application scope.
        /// </summary>
        /// <returns></returns>
        public static ICompositionContext GetOrCreateApplicationScope()
        {
            Contract.Ensures(Contract.Result<ICompositionContext>() != null);

            var app = GetApplicationScope();
            if (app == null)
                RegisterApplicationScope(app = GetDefaultContainer().AsContext());

            return app;
        }

        /// <summary>
        /// Gets the current composition context scope, if available.
        /// </summary>
        /// <returns></returns>
        public static ICompositionContext GetRequestScope()
        {
            var http = HttpContext.Current;
            if (http != null)
            {
                var reference = (IDisposable<ICompositionContext>)http.Items[REQUEST_SCOPE_KEY];
                if (reference != null)
                    return reference.Resource;
            }

            return null;
        }

        /// <summary>
        /// Registers the given composition context.
        /// </summary>
        /// <param name="composition"></param>
        public static void RegisterRequestScope(ICompositionContext composition)
        {
            var http = HttpContext.Current;
            if (http != null)
            {
                if (http.Items.Contains(REQUEST_SCOPE_KEY))
                    return;

                // store in context and increase the reference count
                http.Items[REQUEST_SCOPE_KEY] = composition.AsReference();
            }
        }

        /// <summary>
        /// Unregisters the reference to the request scope.
        /// </summary>
        public static void UnregisterRequestScope()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                var req = (IDisposable<ICompositionContext>)ctx.Items[REQUEST_SCOPE_KEY];
                if (req != null)
                {
                    ctx.Items.Remove(REQUEST_SCOPE_KEY);
                    req.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets or creates and registers the scope for the current request.
        /// </summary>
        /// <returns></returns>
        public static ICompositionContext GetOrCreateRequestScope()
        {
            Contract.Ensures(Contract.Result<ICompositionContext>() != null);

            var req = GetRequestScope();
            if (req == null)
                RegisterRequestScope(req = GetOrCreateApplicationScope().GetOrBeginScope<IWebRequestScope>());

            return req;
        }

    }

}
