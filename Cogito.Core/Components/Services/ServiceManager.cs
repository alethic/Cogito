using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Components.Services
{

    [Export(typeof(IServiceManager))]
    public class ServiceManager :
        IServiceManager
    {

        readonly IEnumerable<IService> services;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="services"></param>
        [ImportingConstructor]
        public ServiceManager(
            [ImportMany] IEnumerable<IService> services)
        {
            Contract.Requires<ArgumentNullException>(services != null);

            this.services = services;
        }

        public void Start()
        {
            lock (services)
            {
                var e = services.Select(i => TryStart(i)).Where(i => i != null).ToArray();
                if (e.Any())
                    throw new AggregateException(e).Flatten();
            }
        }

        public void Stop()
        {
            lock (services)
            {
                var e = services.Select(i => TryStop(i)).Where(i => i != null).ToArray();
                if (e.Any())
                    throw new AggregateException(e).Flatten();
            }
        }

        Exception TryStart(IService service)
        {
            Trace.TraceInformation("ServiceManager: TryStart ({0})", service.GetType().FullName);

            try
            {
                service.Start();
                return null;
            }
            catch (Exception e)
            {
                e.Trace();
                return e;
            }
        }

        Exception TryStop(IService service)
        {
            Trace.TraceInformation("ServiceManager: TryStop ({0})", service.GetType().FullName);

            try
            {
                service.Stop();
                return null;
            }
            catch (Exception e)
            {
                e.Trace();
                return e;
            }
        }

    }

}
