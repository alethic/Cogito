using System.ComponentModel.Composition;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Indicates that the layout view supports children items of type <typeparamref name="TView"/>.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public interface INancyRazorLayoutView<TView, TModel> :
        INancyRazorView<TModel>,
        INancyRazorLayoutView<TView>
        where TView : INancyRazorView
    {



    }

    /// <summary>
    /// Indicates that the layout view supports children items of type <typeparamref name="TView"/>.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public interface INancyRazorLayoutView<TView> :
        INancyRazorView,
        INancyRazorLayoutView
        where TView : INancyRazorView
    {



    }

    /// <summary>
    /// Indicates the view is a layout view.
    /// </summary>
    [InheritedExport(typeof(INancyRazorLayoutView))]
    public interface INancyRazorLayoutView :
        INancyRazorView
    {



    }

}
