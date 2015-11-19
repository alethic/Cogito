using Cogito.Web.Razor;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Model-associated partial view.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface INancyRazorPartialView<TModel> :
        INancyRazorPartialView,
        INancyRazorView<TModel>
    {



    }

    /// <summary>
    /// Model-associated partial view.
    /// </summary>
    public interface INancyRazorPartialView :
        IRazorTemplate,
        INancyRazorView
    {



    }

}
