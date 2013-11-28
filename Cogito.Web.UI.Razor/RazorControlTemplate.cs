using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web;
using System.Web.UI;
using Cogito.Web.Razor;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Base non-generic Razor template type for server controls that is applied during the Render phase.
    /// </summary>
    public abstract class RazorControlTemplate :
        RazorTemplate,
        IRazorControlTemplate
    {

        readonly IDictionary<string, Action> sections;
        HtmlTextWriter writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RazorControlTemplate()
        {
            this.sections = new Dictionary<string, Action>();
        }

        /// <summary>
        /// Gets the type of control this template will render.
        /// </summary>
        public virtual Type ControlType
        {
            get { return Control.GetType(); }
        }

        /// <summary>
        /// Gets the control being rendered.
        /// </summary>
        public abstract System.Web.UI.Control Control { get; }

        /// <summary>
        /// Gets the control being rendered.
        /// </summary>
        protected System.Web.UI.Control _
        {
            get { return Control; }
        }

        /// <summary>
        /// Gets an accessor to access the protected properties of the control.
        /// </summary>
        IRazorControlAccessor ControlAccessor
        {
            get { return Control as IRazorControlAccessor; }
        }

        /// <summary>
        /// Gets the <see cref="HttpContext"/>.
        /// </summary>
        protected HttpContextBase Context
        {
            get { return ControlAccessor != null ? ControlAccessor.Context : null; }
        }

        /// <summary>
        /// Gets the <see cref="HttpRequestBase"/> object for the current request.
        /// </summary>
        protected HttpRequestBase Request
        {
            get { return Context != null ? Context.Request : null; }
        }

        /// <summary>
        /// Gets the <see cref="HttpResponseBase"/> object for the current request.
        /// </summary>
        protected HttpResponseBase Response
        {
            get { return Context != null ? Context.Response : null; }
        }

        /// <summary>
        /// Gets the view state bag of the control.
        /// </summary>
        protected StateBag ViewState
        {
            get { return ControlAccessor != null ? ControlAccessor.ViewState : null; }
        }

        /// <summary>
        /// Gets the currently active writer.
        /// </summary>
        public HtmlTextWriter CurrentWriter
        {
            get { return writer; }
        }

        /// <summary>
        /// Gets the child control with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public System.Web.UI.Control FindControl(string id)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(id));

            return FindControl<CogitoControl>(id);
        }

        /// <summary>
        /// Gets the child control with the specified ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindControl<T>(string id)
            where T : System.Web.UI.Control
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(id));

            return (T)Control.FindControl(id);
        }

        /// <summary>
        /// Writes the specified value.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(object value)
        {
            WriteTo(writer, value);
        }

        /// <summary>
        /// Writes the specified value.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteTo(TextWriter writer, object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<InvalidOperationException>(CurrentWriter != null);

            if (value == null)
                return;
            else if (value is string)
                (writer as HtmlTextWriter ?? new HtmlTextWriter(writer)).WriteEncodedText((string)value);
            else if (value is CogitoControl)
                ((CogitoControl)value).RenderControl(writer as HtmlTextWriter ?? new HtmlTextWriter(writer));
            else if (value is HelperResult)
                ((HelperResult)value).WriteTo(writer);
            else if (value is Cogito.Web.Razor.IHtmlString)
                writer.Write(((Cogito.Web.Razor.IHtmlString)value).ToHtmlString());
            else if (value is System.Web.IHtmlString)
                writer.Write(((System.Web.IHtmlString)value).ToHtmlString());
            else
                (writer as HtmlTextWriter ?? new HtmlTextWriter(writer)).WriteEncodedText(value.ToString());
        }

        /// <summary>
        /// Writes the value as a literal.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLiteral(object value)
        {
            WriteLiteralTo(writer, value);
        }

        /// <summary>
        /// Writes the value as a literal.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public override void WriteLiteralTo(TextWriter writer, object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<InvalidOperationException>(CurrentWriter != null);

            if (value == null)
                return;
            else if (value is string)
                writer.Write((string)value);
            else
                writer.Write(value.ToString());
        }

        /// <summary>
        /// Writes an attribute value.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="token1"></param>
        /// <param name="token2"></param>
        /// <param name="token3"></param>
        public override void WriteAttribute(
            string attr,
            Tuple<string, int> ltoken,
            Tuple<string, int> rtoken,
            params AttributeValue[] values)
        {
            Contract.Requires<ArgumentNullException>(attr != null);
            Contract.Requires<ArgumentNullException>(ltoken != null);
            Contract.Requires<ArgumentNullException>(rtoken != null);
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<InvalidOperationException>(CurrentWriter != null);

            WriteAttributeTo(writer, attr, ltoken, rtoken, values);
        }

        /// <summary>
        /// Writes an attribute value.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="ltoken"></param>
        /// <param name="rtoken"></param>
        /// <param name="values"></param>
        public override void WriteAttributeTo(
            TextWriter writer,
            string attr,
            Tuple<string, int> ltoken,
            Tuple<string, int> rtoken,
            params AttributeValue[] values)
        {
            Contract.Requires<ArgumentNullException>(attr != null);
            Contract.Requires<ArgumentNullException>(ltoken != null);
            Contract.Requires<ArgumentNullException>(rtoken != null);
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<InvalidOperationException>(CurrentWriter != null);

            writer.Write(ltoken.Item1);

            foreach (var value in values)
                if (value != null)
                    writer.Write(value.Value);

            writer.Write(rtoken.Item1);
        }

        /// <summary>
        /// Renders the specified <see cref="Control"/>.
        /// </summary>
        /// <param name="control"></param>
        protected void Write(CogitoControl control)
        {
            Contract.Requires<ArgumentNullException>(control != null, "Cannot render null Control instance.");
            Contract.Requires<InvalidOperationException>(CurrentWriter != null);

            control.RenderControl(CurrentWriter);
        }

        /// <summary>
        /// Writes the template to the specified <see cref="HtmlTextWriter"/>.
        /// </summary>
        /// <param name="writer"></param>
        public void Render(HtmlTextWriter writer)
        {
            Contract.Requires<ArgumentNullException>(writer != null);

            var previousWriter = this.writer;

            try
            {
                this.writer = writer;
                Execute();
            }
            finally
            {
                this.writer = previousWriter;
            }
        }

        /// <summary>
        /// Gets the ClientID of the given control.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected string IdOf(CogitoControl control)
        {
            Contract.Requires<ArgumentNullException>(control != null);

            return control.ClientID;
        }
        
        /// <summary>
        /// Gets the defined sections.
        /// </summary>
        public IDictionary<string, Action> Sections
        {
            get { return sections; }
        }

        /// <summary>
        /// Returns <c>true</c> if the specified section exists.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public override bool IsSectionDefined(string sectionName)
        {
            return sections.ContainsKey(sectionName);
        }

        /// <summary>
        /// Defines a new section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="action"></param>
        public override void DefineSection(string sectionName, Action action)
        {
            sections[sectionName] = action;
        }

    }

    /// <summary>
    /// Hides the non-generic version of Control.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public abstract class RazorControlTemplateInternal<TControl> :
        RazorControlTemplate
        where TControl : System.Web.UI.Control
    {

        public override System.Web.UI.Control Control
        {
            get { return ControlInternal; }
        }

        internal protected abstract TControl ControlInternal { get; }

    }

    /// <summary>
    /// Recommended base <see cref="ITemplate"/> implementation for <see cref="RazorControl"/> web controls.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    public abstract class RazorControlTemplate<TControl> :
        RazorControlTemplateInternal<TControl>,
        IRazorControlTemplate<TControl>
        where TControl : System.Web.UI.Control
    {

        /// <summary>
        /// Gets the type of control this template will render.
        /// </summary>
        public override Type ControlType
        {
            get { return typeof(TControl); }
        }

        /// <summary>
        /// Gets the control being rendered.
        /// </summary>
        public new TControl Control { get; internal set; }

        /// <summary>
        /// Gets the control being rendered.
        /// </summary>
        public new TControl _
        {
            get { return Control; }
        }

        /// <summary>
        /// Provides a shadow of Control.
        /// </summary>
        internal protected override TControl ControlInternal
        {
            get { return Control; }
        }

    }

}
