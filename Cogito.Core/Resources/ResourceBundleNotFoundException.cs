using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Cogito.Resources
{

    public class ResourceBundleNotFoundException : 
        Exception
    {

        /// <summary>
        /// Converts the given expression into a string.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string ExpressionToString(Expression<Func<IResourceBundle, bool>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null);

            return expression.ToString();
        }

        readonly string bundleId;
        readonly string version;
        readonly Expression<Func<IResourceBundle, bool>> expression;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        public ResourceBundleNotFoundException(string bundleId, string version)
            : base("Could not find the specified resource.")
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);

            this.bundleId = bundleId;
            this.version = version;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundleId"></param>
        public ResourceBundleNotFoundException(string bundleId)
            : base("Could not find the specified resource bundle.")
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);

            this.bundleId = bundleId;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="expression"></param>
        public ResourceBundleNotFoundException(Expression<Func<IResourceBundle, bool>> expression)
            :base("Could not find resource bundle matching expression: " + ExpressionToString(expression))
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

        public Expression<Func<IResourceBundle, bool>> Expression
        {
            get { return expression; }
        }

    }

}
