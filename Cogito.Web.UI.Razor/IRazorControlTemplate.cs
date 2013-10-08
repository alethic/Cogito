using System;
using System.Web.UI;

using Cogito.Web.Razor;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Razor template interface.
    /// </summary>
    public interface IRazorControlTemplate : IRazorTemplate
    {

        /// <summary>
        /// Gets the type of control associated with the template.
        /// </summary>
        Type ControlType { get; }

        /// <summary>
        /// Gets the control associated with the template.
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Finds the control specified by the ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindControl<T>(string id) 
            where T : Control;

        /// <summary>
        /// Renders the template to the given <see cref="HtmlTextWriter"/>.
        /// </summary>
        /// <param name="writer"></param>
        void Render(HtmlTextWriter writer);

    }

    /// <summary>
    /// Razor template interface.
    /// </summary>
    public interface IRazorControlTemplate<TControl> : IRazorControlTemplate
        where TControl : Control
    {

        /// <summary>
        /// Gets the control associated with the template.
        /// </summary>
        new TControl Control { get; }

    }

}
