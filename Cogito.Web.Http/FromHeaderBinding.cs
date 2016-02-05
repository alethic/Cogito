using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Cogito.Web.Http
{

    /// <summary>
    /// Describes how a header parameter is bound.
    /// </summary>
    public class FromHeaderBinding :
        HttpParameterBinding
    {

        readonly string name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="headerName"></param>
        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerName)
            : base(parameter)
        {
            Contract.Requires<ArgumentNullException>(parameter != null);

            this.name = headerName ?? parameter.ParameterName;
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            actionContext.ActionArguments[Descriptor.ParameterName] = TryGetHeaderValue(actionContext.Request.Headers, name);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Gets the first value of the header.
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        string TryGetHeaderValue(HttpHeaders headers, string name)
        {
            IEnumerable<string> values;
            headers.TryGetValues(name, out values);
            return values != null ? values.FirstOrDefault() : null;
        }
    }

}
