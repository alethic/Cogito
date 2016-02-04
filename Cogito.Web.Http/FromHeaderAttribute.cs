using System.Web.Http;
using System.Web.Http.Controllers;

namespace Cogito.Web.Http
{

    /// <summary>
    /// An attribute that specifies that an action parameter comes only from the a header of the incoming <see cref="System.Net.Http.HttpRequestMessage"/>.
    /// </summary>
    public class FromHeaderAttribute :
        ParameterBindingAttribute
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

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, Name);
        }

        /// <summary>
        /// Gets or sets the header name.
        /// </summary>
        public string Name { get; set; }

    }

}
