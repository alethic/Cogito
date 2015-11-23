using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.ServiceBus
{

    public static class ServiceBusExtensions
    {

        /// <summary>
        /// Asynchronously publishes a request message and returns an awaitable for a response.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="bus"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Task<TResponse> PublishRequest<TRequest, TResponse>(this IServiceBus bus, TRequest request)
            where TRequest : class
            where TResponse : class
        {
            var t = new TaskCompletionSource<TResponse>();

            // publish request
            bus.PublishRequest(request,
                i =>
                {
                    // handle response
                    i.Handle<TResponse>(j =>
                    {
                        t.SetResult(j);
                    });
                    
                    // handle exception
                    i.HandleFault(j =>
                    {
                        t.SetException(new Exception(j.Message.Messages.First()));
                    });
                }, i => { });

            // return awaitable
            return t.Task;
        }

    }

}
