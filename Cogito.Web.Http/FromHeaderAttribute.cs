using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

using Cogito.Web.Http.ValueProviders;

namespace Cogito.Web.Http
{

    /// <summary>
    /// An attribute that specifies that an action parameter comes only from the a header of the incoming <see cref="System.Net.Http.HttpRequestMessage"/>.
    /// </summary>
    public class FromHeaderAttribute :
        ModelBinderAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FromHeaderAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        public FromHeaderAttribute(string name)
        {
            Name = name;
        }

        public override IEnumerable<ValueProviderFactory> GetValueProviderFactories(HttpConfiguration configuration)
        {
            return base.GetValueProviderFactories(configuration).OfType<IHeaderValueProviderFactory>().Cast<ValueProviderFactory>().DefaultIfEmpty(new HeaderValueProviderFactory());
        }

    }

}
