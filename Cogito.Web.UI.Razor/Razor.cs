using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;

using Cogito.Linq;
using Cogito.Reflection;
using Cogito.Web.Razor;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Provides methods to render <see cref="CogitoControl"/> instances using Razor.
    /// </summary>
    public static class Razor
    {

        static readonly object syncRoot = new object();

        /// <summary>
        /// Invoked dynamically.
        /// </summary>
        static readonly MethodInfo TemplateMethod = typeof(Razor).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(i => i.IsGenericMethodDefinition)
            .First(i => i.Name == "Template");

        /// <summary>
        /// Invoked dynamically.
        /// </summary>
        static readonly MethodInfo RenderMethod = typeof(Razor).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(i => i.IsGenericMethodDefinition)
            .First(i => i.Name == "Render");

        /// <summary>
        /// Looks up the template for the given assembly and name.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        static Stream OpenResourceStream(Assembly assembly, string name)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name));

            // find resource
            return assembly.GetManifestResourceStream(name);
        }

        /// <summary>
        /// Gets the template for the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static TextReader ReadTemplate(Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null);

            // default values
            var asm = type.Assembly;
            var res = type.FullName + ".cshtml";

            // customized values specified on type
            var atr = type.GetCustomAttribute<RazorTemplateAttribute>(true);
            if (atr != null && atr.Assembly != null)
                asm = atr.Assembly;
            if (atr != null && atr.ResourceName != null)
                res = atr.ResourceName;

            // open discovered resource and wrap with reader
            var stm = OpenResourceStream(asm, res);
            if (stm != null)
                return new StreamReader(stm);;

            return null;
        }

        /// <summary>
        /// Gets the template for the specified type, or it's parent types.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static string FindTemplateRecursive(Type type)
        {
            return type
                .Recurse(i => i.BaseType)
                .Select(i => ReadTemplate(i).ReadToEnd())
                .FirstOrDefault(i => i != null);
        }

        /// <summary>
        /// Finds the appropriate template.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static string FindTemplate(Type type)
        {
            var template = FindTemplateRecursive(type);
            if (template == null)
                throw new NullReferenceException("Could not locate Razor template for " + type.Name);

            return template;
        }

        /// <summary>
        /// Loads and returns the template for the specified <see cref="CogitoControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IRazorControlTemplate Template<T>(T control)
            where T : Control
        {
            Contract.Requires<ArgumentNullException>(control != null);

            lock (syncRoot)
            {
                // recursively inherit all references of the control being referenced and ourself
                var referencedAssemblies = Enumerable.Empty<Assembly>()
                    .Append(typeof(Razor).Assembly)
                    .Append(typeof(CogitoControl).Assembly)
                    .Append(typeof(T).Assembly);

                referencedAssemblies = referencedAssemblies
                    .SelectMany(i => i.GetReferencedAssemblies())
                    .Select(i => Assembly.Load(i))
                    .Concat(referencedAssemblies);

                var referencedAssemblyPaths = referencedAssemblies
                    .Select(i => new Uri(i.Location))
                    .Select(i => i.LocalPath);

                // obtain or create the Razor template for the given control
                var type = RazorTemplateBuilder.GetOrBuildType(
                    FindTemplate(typeof(T)),
                    defaultBaseClass: typeof(RazorControlTemplate<T>),
                    referencedAssemblies: referencedAssemblyPaths,
                    importedNamespaces: new[] { typeof(CogitoControl).Namespace },
                    innerTemplateType: typeof(HtmlHelperResult),
                    cacheKey: typeof(T).FullName);
                if (type == null)
                    throw new NullReferenceException("Unable to locate newly generated Type.");

                IRazorControlTemplate template = null;

                // generic constructor
                var ctor1 = type.GetConstructor(new[] { typeof(T) });
                if (ctor1 != null)
                    template = (IRazorControlTemplate)ctor1.Invoke(new[] { control });

                // non generic constructor
                var ctor2 = type.GetConstructor(new[] { typeof(CogitoControl) });
                if (ctor2 != null)
                    template = (IRazorControlTemplate)ctor2.Invoke(new[] { control });

                if (template == null)
                    throw new NullReferenceException("Could not construct new template instance. Could find compatible constructor.");

                return template;
            }
        }

        /// <summary>
        /// Loads and returns the template for the specified <see cref="CogitoControl"/>.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static IRazorControlTemplate Template(Control control, Type controlType)
        {
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(controlType != null);

            return (IRazorControlTemplate)TemplateMethod.MakeGenericMethod(controlType)
                .Invoke(null, new object[] { control });
        }

        /// <summary>
        /// Renders the specified template to the writer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="template"></param>
        public static void Render<T>(HtmlTextWriter writer, IRazorControlTemplate<T> template)
            where T : CogitoControl
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(template != null);

            template.Render(writer);
        }

        /// <summary>
        /// Renders the Razor template configured for the specified <see cref="CogitoControl"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="CogitoControl"/>.Render method.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="control"></param>
        public static void Render(HtmlTextWriter writer, IRazorControlTemplate template)
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(template != null);
            Contract.Requires<ArgumentNullException>(template.Control != null);
            Contract.Requires<ArgumentNullException>(template.ControlType != null);

            RenderMethod.MakeGenericMethod(template.ControlType)
                .Invoke(null, new object[] { writer, template });
        }

        /// <summary>
        /// Renders the Razor template configured for the specified <see cref="CogitoControl"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="CogitoControl"/>.Render method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="control"></param>
        public static void Render<T>(HtmlTextWriter writer, T control)
            where T : CogitoControl
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(control != null);

            var template = Template<T>(control);
            if (template == null)
                throw new RazorException("Could not locate Razor template for {0}.", typeof(T));

            template.Render(writer);
        }

        /// <summary>
        /// Renders the Razor template configured for the specified <see cref="CogitoControl"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="CogitoControl"/>.Render method.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="control"></param>
        /// <param name="controlType"></param>
        public static void Render(HtmlTextWriter writer, CogitoControl control, Type controlType)
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(controlType != null);

            RenderMethod.MakeGenericMethod(controlType)
                .Invoke(null, new object[] { writer, control });
        }

    }

}
