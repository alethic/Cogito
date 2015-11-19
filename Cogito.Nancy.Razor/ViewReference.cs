using System;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Reference to a view instance.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    public class ViewReference<TView>
        where TView : INancyRazorView
    {

        readonly Type viewType;
        readonly Func<TView> getter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="getter"></param>
        public ViewReference(Type viewType, Func<TView> getter)
        {
            this.viewType = viewType;
            this.getter = getter;
        }

        /// <summary>
        /// Gets the concrete type of the view instance.
        /// </summary>
        public Type ViewType
        {
            get { return viewType; }
        }

        /// <summary>
        /// Gets the view instance.
        /// </summary>
        public TView View
        {
            get { return getter(); }
        }

    }

}
