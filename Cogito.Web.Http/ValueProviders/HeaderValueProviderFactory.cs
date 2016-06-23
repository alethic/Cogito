using System.ComponentModel.Composition;
using System.Globalization;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

using Cogito.Collections;

namespace Cogito.Web.Http.ValueProviders
{

    [Export(typeof(ValueProviderFactory))]
    public class HeaderValueProviderFactory :
        ValueProviderFactory,
        IHeaderValueProviderFactory
    {

        const string RequestLocalStorageKey = "C8AE476A-42AE-4934-B798-3F13AFF960E2";

        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return (IValueProvider)actionContext.Request.Properties.GetOrAdd(RequestLocalStorageKey, i => new HeaderValueProvider(actionContext.Request.Headers, CultureInfo.InvariantCulture));
        }

    }

}
