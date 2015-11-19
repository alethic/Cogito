namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Base Nancy layout view type for a model of dynamic type.
    /// </summary>
    public abstract class NancyRazorLayoutViewBase :
        NancyRazorLayoutViewBase<INancyRazorView>
    {



    }

    /// <summary>
    /// Base Nancy layout view type for a model of dynamic type.
    /// </summary>
    public abstract class NancyRazorLayoutViewBase<TView> :
        NancyRazorLayoutViewBase<TView, dynamic>
        where TView : INancyRazorView
    {



    }

    /// <summary>
    /// Base Nancy layout view type for a model of a specific type.
    /// </summary>
    public abstract class NancyRazorLayoutViewBase<TView, TModel> :
        NancyRazorViewBase<TModel>,
        INancyRazorLayoutView<TView, TModel>
        where TView : INancyRazorView
    {



    }

}
