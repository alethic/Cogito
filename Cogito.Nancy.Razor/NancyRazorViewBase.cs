using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Cogito.Composition.Scoping;
using Cogito.Web;
using Cogito.Web.Razor;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Base nancy view type for a model of dynamic type.
    /// </summary>
    public abstract class NancyRazorViewBase : NancyRazorViewBase<dynamic>
    {



    }

    /// <summary>
    /// Base Nancy view type for a model.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Scope(typeof(IRequestScope))]
    public abstract class NancyRazorViewBase<TModel> :
        global::Nancy.ViewEngines.Razor.NancyRazorViewBase<TModel>,
        INancyRazorView<TModel>,
        IRazorTemplate
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyRazorViewBase()
            : base()
        {

        }

        public override void DefineSection(string sectionName, Action action)
        {
            base.DefineSection(sectionName, action);
        }

        /// <summary>
        /// Gets the model associated with the view.
        /// </summary>
        object INancyRazorView.Model
        {
            get { return Model; }
        }

        #region IRazorTemplate Methods

        void IRazorTemplate.Write(object value)
        {
            base.Write(value);
        }

        void IRazorTemplate.Write(IHtmlString result)
        {
            base.WriteLiteral(result);
        }

        void IRazorTemplate.WriteTo(TextWriter writer, object value)
        {
            base.WriteTo(writer, value);
        }

        void IRazorTemplate.WriteTo(TextWriter writer, IHtmlString result)
        {
            base.WriteLiteralTo(writer, result);
        }

        void IRazorTemplate.WriteLiteral(object value)
        {
            base.WriteLiteral(value);
        }

        void IRazorTemplate.WriteLiteralTo(TextWriter writer, object value)
        {
            base.WriteLiteralTo(writer, value);
        }

        void IRazorTemplate.WriteAttribute(string attr, Tuple<string, int> ltoken, Tuple<string, int> rtoken, params AttributeValue[] values)
        {
            base.WriteAttribute(attr, ltoken, rtoken,
                values
                    .Select(i => new global::Nancy.ViewEngines.Razor.AttributeValue(
                         Tuple.Create(i.Prefix, 0),
                         Tuple.Create(i.Value, 0),
                         i.IsLiteral))
                    .ToArray());
        }

        void IRazorTemplate.WriteAttributeTo(TextWriter writer, string attr, Tuple<string, int> ltoken, Tuple<string, int> rtoken, params AttributeValue[] values)
        {
            base.WriteAttributeTo(writer, attr, ltoken, rtoken,
                values
                    .Select(i => new global::Nancy.ViewEngines.Razor.AttributeValue(
                         Tuple.Create(i.Prefix, 0),
                         Tuple.Create(i.Value, 0),
                         i.IsLiteral))
                    .ToArray());
        }

        object IRazorTemplate.Layout
        {
            get { throw new NotImplementedException(); }
        }

        void IRazorTemplate.DefineSection()
        {
            throw new NotImplementedException();
        }

        void IRazorTemplate.BeginContext()
        {
            throw new NotImplementedException();
        }

        void IRazorTemplate.EndContext()
        {
            throw new NotImplementedException();
        }

        #endregion

    }

}
