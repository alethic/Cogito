using System;
using System.Runtime.Caching;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

using Cogito.Runtime.Caching;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Implements a route supporting URL path arguments for a WCF service.
    /// </summary>
    public class DynamicServiceRoute :
        RouteBase,
        IRouteHandler
    {

        /// <summary>
        /// Gets the current route data.
        /// </summary>
        /// <returns></returns>
        public static RouteData GetCurrentRouteData()
        {
            if (HttpContext.Current != null)
                return new HttpContextWrapper(HttpContext.Current).Request.RequestContext.RouteData;

            return null;
        }

        /// <summary>
        /// Gets or adds the service route for the given URL path.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static ServiceRoute GetServiceRoute(string url, ServiceHostFactoryBase serviceHostFactory, Type serviceType)
        {
            return MemoryCache.Default.GetOrCreate(url, () => new ServiceRoute(url, new DynamicServiceRouteServiceHostFactory(serviceHostFactory), serviceType), TimeSpan.FromMinutes(5));
        }

        readonly string url;
        readonly Func<RequestContext, IHttpHandler> requestHandlerFunc;
        readonly ServiceHostFactoryBase serviceHostFactory;
        readonly Type serviceType;
        readonly Route innerRoute;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="defaults"></param>
        /// <param name="serviceHostFactory"></param>
        /// <param name="serviceType"></param>
        /// <param name="requestHandlerFunc"></param>
        public DynamicServiceRoute(string url, object defaults, ServiceHostFactoryBase serviceHostFactory, Type serviceType, Func<RequestContext, IHttpHandler> requestHandlerFunc = null)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentOutOfRangeException(nameof(url));
            if (url.IndexOf("{*") >= 0)
                throw new ArgumentException("Url cannot include catch-all route parameters.", nameof(url));
            if (serviceHostFactory == null)
                throw new ArgumentNullException(nameof(serviceHostFactory));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            // append separator
            if (url.EndsWith("/") == false)
                url += "/";

            // append service path specification
            url += "{*servicePath}";

            this.url = url;
            this.requestHandlerFunc = requestHandlerFunc ?? (_ => null);
            this.serviceHostFactory = serviceHostFactory;
            this.serviceType = serviceType;
            this.innerRoute = new Route(url, new RouteValueDictionary(defaults), this);
        }

        /// <summary>
        /// Returns information about the requested route.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            return innerRoute.GetRouteData(httpContext);
        }

        /// <summary>
        /// Returns information about the URL that is associated with the route.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return innerRoute.GetVirtualPath(requestContext, values);
        }

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return requestHandlerFunc(requestContext) ?? GetServiceRoute(requestContext).RouteHandler.GetHttpHandler(requestContext);
        }

        /// <summary>
        /// Gets the service route for the current request context.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        ServiceRoute GetServiceRoute(RequestContext requestContext)
        {
            return GetServiceRoute(requestContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2), serviceHostFactory, serviceType);
        }

    }

}