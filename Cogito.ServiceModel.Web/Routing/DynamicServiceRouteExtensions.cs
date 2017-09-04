using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Various extension methods for registering <see cref="DynamicServiceRoute"/>s.
    /// </summary>
    public static class DynamicServiceRouteExtensions
    {

        /// <summary>
        /// Routes the given URL pattern to the specified WCF service.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="url"></param>
        /// <param name="serviceHostFactory"></param>
        /// <param name="serviceType"></param>
        public static void AddDynamicServiceRoute<TService>(
            this RouteCollection self,
            string url,
            ServiceHostFactoryBase serviceHostFactory,
            object defaults = null,
            Func<RequestContext, IHttpHandler> requestHandlerFunc = null)
            where TService : class
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            self.Add(new DynamicServiceRoute(url, defaults, serviceHostFactory, typeof(TService), requestHandlerFunc));
        }

        /// <summary>
        /// Routes the given URL pattern to the specified WCF service.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="url"></param>
        /// <param name="defaults"></param>
        /// <param name="requestHandlerFunc"></param>
        public static void AddDynamicServiceRoute<TService, TServiceHostFactory>(
            this RouteCollection self,
            string url,
            object defaults = null,
            Func<RequestContext, IHttpHandler> requestHandlerFunc = null)
            where TService : class
            where TServiceHostFactory : ServiceHostFactoryBase, new()
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            self.Add(new DynamicServiceRoute(url, defaults, new TServiceHostFactory(), typeof(TService), requestHandlerFunc));
        }

        /// <summary>
        /// Routes the given URL pattern to the specified WCF service.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="url"></param>
        /// <param name="serviceHostFactory"></param>
        /// <param name="serviceType"></param>
        /// <param name="defaults"></param>
        /// <param name="requestHandlerFunc"></param>
        public static void AddDynamicServiceRoute(
            this RouteCollection self,
            string url,
            ServiceHostFactoryBase serviceHostFactory,
            Type serviceType,
            object defaults = null,
            Func<RequestContext, IHttpHandler> requestHandlerFunc = null)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            self.Add(new DynamicServiceRoute(url, defaults, serviceHostFactory, serviceType));
        }

    }

}
