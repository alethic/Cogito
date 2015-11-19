using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Text;

using Cogito.Composition;
using Cogito.Composition.Scoping;
using Cogito.Web;
using Cogito.Web.Razor;

using Nancy;
using Nancy.Helpers;
using Nancy.ViewEngines.Razor;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Base nancy view type for a model of dynamic type.
    /// </summary>
    public abstract class NancyRazorViewBase :
        NancyRazorViewBase<dynamic>
    {



    }

    /// <summary>
    /// Base Nancy view type for a model.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [InheritedPartCreationPolicy(CreationPolicy.NonShared)]
    [PartScope(typeof(IWebRequestScope))]
    public abstract class NancyRazorViewBase<TModel> :
        RazorTemplate,
        INancyRazorView<TModel>
    {

        /// <summary>
        /// Html encodes an object if required
        /// </summary>
        /// <param name="value">Object to potentially encode</param>
        /// <returns>String representation, encoded if necessary</returns>
        static string HtmlEncode(object value)
        {
            if (value == null)
                return null;

            var str = value as IHtmlString;
            return str != null ? str.ToHtmlString() : HttpUtility.HtmlEncode(Convert.ToString(value, CultureInfo.CurrentCulture));
        }


        INancyRazorRenderContext renderContext;
        dynamic viewBag;
        TModel model;
        HtmlHelpers<TModel> html;
        UrlHelpers<TModel> url;

        // output
        StringWriter contents;

        // view definitions
        string name;
        string layout;
        IDictionary<string, Action> sections;

        // produced output
        string body;
        IDictionary<string, string> sectionContents;

        // child items for Render methods
        string childBody;
        IDictionary<string, string> childSections;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyRazorViewBase()
            : base()
        {
            this.contents = new StringWriter();
            this.sections = new Dictionary<string, Action>();
        }

        /// <summary>
        /// Initializes the view.
        /// </summary>
        /// <param name="renderContext"></param>
        /// <param name="model"></param>
        public virtual void Initialize(
            INancyRazorRenderContext renderContext,
            object model)
        {
            this.renderContext = renderContext;
            this.viewBag = renderContext.Context.ViewBag;
            this.model = (TModel)model;
            this.html = new HtmlHelpers<TModel>(renderContext, (TModel)model);
            this.url = new UrlHelpers<TModel>(renderContext);
        }

        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets the name of the layout of the view.
        /// </summary>
        public string Layout
        {
            get { return layout; }
            set { layout = value; }
        }

        /// <summary>
        /// Gets a dynamic object onto which arbitrary properties can be set.
        /// </summary>
        public dynamic ViewBag
        {
            get { return viewBag; }
        }

        /// <summary>
        /// Gets the model associated with the view.
        /// </summary>
        public TModel Model
        {
            get { return model; }
        }

        /// <summary>
        /// Implements INancyRazorView.Model.
        /// </summary>
        object INancyRazorView.Model
        {
            get { return model; }
        }

        /// <summary>
        /// Gets helpers to generate HTML content.
        /// </summary>
        public HtmlHelpers<TModel> Html
        {
            get { return html; }
        }

        /// <summary>
        /// Gets helpers for working with urls.
        /// </summary>
        public UrlHelpers<TModel> Url
        {
            get { return url; }
        }

        #region Template Methods

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Write(object value)
        {
            WriteTo(contents, value);
        }

        public override void WriteTo(TextWriter writer, object value)
        {
            writer.Write(HtmlEncode(value));
        }

        public override void WriteLiteral(object value)
        {
            WriteLiteralTo(contents, value);
        }

        public override void WriteLiteralTo(TextWriter writer, object value)
        {
            writer.Write(value);
        }

        public override void WriteAttribute(string attr, Tuple<string, int> ltoken, Tuple<string, int> rtoken, params Web.Razor.AttributeValue[] values)
        {
            WriteAttributeTo(contents, attr, ltoken, rtoken, values);
        }

        public override void WriteAttributeTo(TextWriter writer, string attr, Tuple<string, int> ltoken, Tuple<string, int> rtoken, params Web.Razor.AttributeValue[] values)
        {
            WriteLiteralTo(writer, BuildAttribute(attr, ltoken, rtoken, values));
        }

        /// <summary>
        /// Builds an attribute into a string.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        string BuildAttribute(string name, Tuple<string, int> prefix, Tuple<string, int> suffix, params AttributeValue[] values)
        {
            var writtenAttribute = false;
            var attributeBuilder = new StringBuilder(prefix.Item1);

            foreach (var value in values)
            {
                if (ShouldWriteValue(value.Value))
                {
                    var stringValue = GetStringValue(value);
                    var valuePrefix = value.Prefix;

                    if (!string.IsNullOrEmpty(valuePrefix))
                        attributeBuilder.Append(valuePrefix);

                    attributeBuilder.Append(stringValue);
                    writtenAttribute = true;
                }
            }

            attributeBuilder.Append(suffix.Item1);

            var renderAttribute = writtenAttribute || values.Length == 0;
            if (renderAttribute)
                return attributeBuilder.ToString();

            return string.Empty;
        }

        /// <summary>
        /// Gets the string value for the given attribute.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetStringValue(AttributeValue value)
        {
            if (value.IsLiteral)
                return (string)value.Value;

            if (value.Value is IHtmlString)
                return ((IHtmlString)value.Value).ToHtmlString();

            if (value.Value is DynamicDictionaryValue)
            {
                var dynamicValue = (DynamicDictionaryValue)value.Value;
                return dynamicValue.HasValue ? dynamicValue.Value.ToString() : string.Empty;
            }

            return value.Value.ToString();
        }

        /// <summary>
        /// Returns <c>true</c> if the value should be written.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ShouldWriteValue(object value)
        {
            if (value == null)
                return false;

            if (value is bool)
                return (bool)value;

            return true;
        }

        /// <summary>
        /// Indicates if a section is defined.
        /// </summary>
        public override bool IsSectionDefined(string sectionName)
        {
            return childSections.ContainsKey(sectionName);
        }

        /// <summary>
        /// Stores sections
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="action">The action.</param>
        public override void DefineSection(string sectionName, Action action)
        {
            sections.Add(sectionName, action);
        }

        #endregion

        /// <summary>
        /// Renders the body.
        /// </summary>
        /// <returns></returns>
        public object RenderBody()
        {
            WriteLiteral(childBody);
            return null;
        }

        /// <summary>
        /// Renders the section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns></returns>
        public object RenderSection(string sectionName)
        {
            return RenderSection(sectionName, true);
        }

        /// <summary>
        /// Renders the section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        public object RenderSection(string sectionName, bool required)
        {
            string sectionContent;

            var exists = childSections.TryGetValue(sectionName, out sectionContent);
            if (!exists && required)
                throw new InvalidOperationException("Section name " + sectionName + " not found and is required.");

            WriteLiteral(sectionContent);
            return null;
        }

        /// <summary>
        /// Renders the specified model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public object RenderPartial<T>(T model)
        {
            return RenderPartial(model, null);
        }

        /// <summary>
        /// Renders the specified model with the view with the given name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public object RenderPartial<T>(T model, string viewName)
        {
            var writer = new StringWriter();
            renderContext.RenderPartial(model, viewName, writer);
            return Html.Raw(writer.ToString());
        }

        /// <summary>
        /// Resolves the given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual string ResolveUrl(string url)
        {
            return renderContext.ParsePath(url);
        }

        /// <summary>
        /// Gets the produced body.
        /// </summary>
        public string Body
        {
            get { return body; }
        }

        /// <summary>
        /// Gets the produced sections.
        /// </summary>
        public IDictionary<string, string> SectionContents
        {
            get { return sectionContents; }
        }

        /// <summary>
        /// Executes the view.
        /// </summary>
        /// <param name="childBody">The body.</param>
        /// <param name="childSections">The section contents.</param>
        public void ExecuteView(string childBody, IDictionary<string, string> childSections)
        {
            this.childBody = childBody ?? string.Empty;
            this.childSections = childSections ?? new Dictionary<string, string>();

            try
            {
                // attempt to execute the view
                Execute();
            }
            catch (NullReferenceException e)
            {
                throw new ViewRenderException("Unable to render the view.  Most likely the Model, or a property on the Model, is null", e);
            }

            body = contents.ToString();
            sectionContents = new Dictionary<string, string>(sections.Count);

            foreach (var section in sections)
            {
                contents = new StringWriter();

                try
                {
                    section.Value.Invoke();
                }
                catch (NullReferenceException e)
                {
                    throw new ViewRenderException(string.Format("A null reference was encountered while rendering the section {0}.  Does the section require a model? (maybe it wasn't passed in)", section.Key), e);
                }

                sectionContents.Add(section.Key, contents.ToString());
            }
        }

    }

}
