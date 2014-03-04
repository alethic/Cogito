using System.Web;
using System.Web.UI;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Provides methods to access protected properties of a <see cref="CogitoControl"/> from within a Razor template.
    /// </summary>
    public interface IRazorControlAccessor
    {

        /// <summary>
        /// Gets the <see cref="HttpContext"/> of the control.
        /// </summary>
        HttpContextBase Context { get; }

        /// <summary>
        /// Gets the view state bag of the control.
        /// </summary>
        StateBag ViewState { get; }

    }

}
