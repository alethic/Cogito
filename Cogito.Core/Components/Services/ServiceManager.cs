using System.Collections.Generic;
using System.ComponentModel.Composition;

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
            this.services = services;
        }

        public void Start()
        {
            foreach (var svc in services)
                svc.Start();
        }

        public void Stop()
        {
            foreach (var svc in services)
                svc.Stop();
        }
    }

}
