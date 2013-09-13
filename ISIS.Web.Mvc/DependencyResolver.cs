using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http.Dependencies;

namespace ISIS.Web.Mvc
{

    [Export(typeof(IDependencyResolver))]
    [Export(typeof(IDependencyScope))]
    public class DependencyResolver : IDependencyResolver
    {

        /// <summary>
        /// Gets the <see cref="ICompositionService"/> which serves the scope.
        /// </summary>
        ICompositionService composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public DependencyResolver(
            ICompositionService composition)
        {
            Contract.Requires<ArgumentNullException>(composition != null);

            this.composition = composition;
        }

        public IDependencyScope BeginScope()
        {
            return new DependencyResolver(composition.CreateScope());
        }

        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return composition.GetExportedValues(serviceType);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            if (composition != null)
            {
                composition.Dispose();
                composition = null;
            }
        }

    }

}
