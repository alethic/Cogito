using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Cogito.Resources
{

    public class ResourceNotFoundException : Exception
    {

        /// <summary>
        /// Converts the given expression into a string.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string ExpressionToString(Expression<Func<IResource, bool>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null);

            return expression.ToString();
        }

        readonly string bundleId;
        readonly string version;
        readonly string resourceName;
        readonly Expression<Func<IResource, bool>> expression;

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

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="expression"></param>
        public ResourceNotFoundException(Expression<Func<IResource, bool>> expression)
            :base("Could not find resource matching expression: " + ExpressionToString(expression))
        {
            Contract.Requires<ArgumentNullException>(expression != null);

            this.expression = expression;
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

        public Expression<Func<IResource, bool>> Expression
        {
            get { return expression; }
        }

    }

}
