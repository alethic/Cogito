using System;
using System.Web.UI.HtmlControls;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Provides extensions that make working with <see cref="CogitoControl"/> instances easier.
    /// </summary>
    public static class ControlExtensions
    {

        /// <summary>
        /// 
        /// Adds the given content to the body of the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T WithContent<T>(this T control, Action<object> action)
            where T : CogitoControl
        {
            control.Controls.Add(new HtmlHelperControl(action));
            return control;
        }

        /// <summary>
        /// Generates a '<label />' element for the given <see cref="CogitoControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public static HtmlGenericControl HtmlLabelFor<T>(this T control, string label)
            where T : CogitoControl
        {
            var l = new HtmlGenericControl("label");
            l.Attributes["for"] = control.ClientID;
            l.InnerText = label;
            return l;
        }

    }

}
