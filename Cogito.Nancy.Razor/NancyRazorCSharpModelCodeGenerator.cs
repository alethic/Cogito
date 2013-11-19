using System.Web.Razor.Generator;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Sets the base type from the @model directive.
    /// </summary>
    public class NancyRazorCSharpModelCodeGenerator : 
        SetBaseTypeCodeGenerator
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="modelType"></param>
        public NancyRazorCSharpModelCodeGenerator(string modelType)
            : base(string.Format("Cogito.Nancy.Razor.NancyRazorViewBase<{0}>", modelType))
        {

        }

    }

}
