using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http.Dependencies;

using Cogito.Composition;

namespace Cogito.Web.Http.Dependencies
{

    [Export(typeof(IDependencyResolver))]
    [Export(typeof(IDependencyScope))]
    public class DependencyResolver : IDependencyResolver
    {

        /// <summary>
        /// Gets the <see cref="ICompositionService"/> which serves the scope.
        /// </summary>
        ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public DependencyResolver(
            ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(composition != null);

            this.composition = composition;
        }

        public IDependencyScope BeginScope()
        {
            return new DependencyResolver(composition.BeginScope());
        }

        public object GetService(Type serviceType)
        {
            Contract.Requires<ArgumentNullException>(serviceType != null);

            return GetServices(serviceType).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Contract.Requires<ArgumentNullException>(serviceType != null);

            return composition.GetExportedValues(serviceType);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Contract.Ensures(composition == null);

            if (composition != null)
            {
                composition.Dispose();
                composition = null;
            }
        }

    }

}
