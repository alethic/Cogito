using System;
using System.CodeDom;
using System.Globalization;
using System.Web.Compilation;
using System.Web.Razor;

using Nancy.ViewEngines.Razor;

namespace Cogito.Nancy.Razor
{

    public class CSharpRazorBuildProvider : global::Nancy.ViewEngines.Razor.BuildProviders.NancyCSharpRazorBuildProvider
    {

        NancyRazorEngineHost host;
        CodeCompileUnit generatedCode;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CSharpRazorBuildProvider()
            : base()
        {
            this.host = new NancyRazorEngineHost(new CSharpRazorCodeLanguage());
        }
        public override void GenerateCode(AssemblyBuilder assemblyBuilder)
        {
            assemblyBuilder.AddCodeCompileUnit(this, GetGeneratedCode());
            assemblyBuilder.GenerateTypeFactory(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[] 
            { 
                host.DefaultNamespace, 
                host.DefaultClassName
            }));
        }

        CodeCompileUnit GetGeneratedCode()
        {
            if (generatedCode == null)
            {
                var engine = new RazorTemplateEngine(host);

                GeneratorResults results;
                using (var reader = OpenReader())
                    results = engine.GenerateCode(reader);

                if (!results.Success)
                    throw new InvalidOperationException(results.ToString());

                generatedCode = results.GeneratedCode;
            }

            return generatedCode;
        }

    }

}
