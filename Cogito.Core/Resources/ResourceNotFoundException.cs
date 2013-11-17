using System;
using System.Diagnostics.Contracts;

namespace Cogito.Resources
{

    public class ResourceNotFoundException : Exception
    {

        readonly string bundleId;
        readonly string version;
        readonly string resourceName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        /// <param name="resourceName"></param>
        public ResourceNotFoundException(string bundleId, string version, string resourceName)
            : base("Could not find the specified resource.")
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            this.bundleId = bundleId;
            this.version = version;
            this.resourceName = resourceName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="resourceName"></param>
        public ResourceNotFoundException(string bundleId, string resourceName)
            : base("Could not find the specified resource.")
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            this.bundleId = bundleId;
            this.resourceName = resourceName;
        }

        public string BundleId
        {
            get { return bundleId; }
        }

        public string Version
        {
            get { return version; }
        }

        public string Name
        {
            get { return resourceName; }
        }

    }

}
