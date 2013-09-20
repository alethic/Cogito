using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;

using Cogito.Composition;

namespace Cogito.Web.Mvc.Internal
{

    [Export(typeof(IDependencyResolver))]
    public class DependencyResolver : System.Web.Mvc.IDependencyResolver
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

        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return composition.GetExportedValues(serviceType);
        }

    }

}
