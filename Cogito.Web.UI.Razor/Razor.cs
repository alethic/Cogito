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
    /// Provides methods to render <see cref="Control"/> instances using Razor.
    /// </summary>
    public static class Razor
    {

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
            var res = assembly.GetManifestResourceStream(name);
            if (res == null)
                throw new RazorException("Unable to locate Razor template {0}.{1}.", assembly, name);

            return res;
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

            // return new reader
            return new StreamReader(OpenResourceStream(asm, res));
        }

        /// <summary>
        /// Loads and returns the template for the specified <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IRazorControlTemplate Template<T>(T control)
            where T : Control
        {
            Contract.Requires<ArgumentNullException>(control != null);

            // recursively inherit all references of the control being referenced and ourself
            var referencedAssemblies = Enumerable.Empty<Assembly>()
                .Append(typeof(Razor).Assembly)
                .Append(typeof(Control).Assembly)
                .Append(typeof(T).Assembly)
                .Select(i => i.LoadAllReferencedAssemblies())
                .SelectMany(i => i)
                .Select(i => new Uri(i.Location))
                .Select(i => i.LocalPath);

            // obtain or create the Razor template for the given control
            var type = RazorTemplateBuilder.GetOrBuildType(
                () => ReadTemplate(typeof(T)),
                baseClassType: typeof(RazorControlTemplate<T>),
                referencedAssemblies: referencedAssemblies,
                importedNamespaces: new[] { typeof(Control).Namespace },
                innerTemplateType: typeof(HtmlHelperResult),
                cacheKey: typeof(T).FullName);
            if (type == null)
                throw new NullReferenceException("Unable to locate newly generated Type.");

            object template = null;

            // generic constructor
            var ctor1 = type.GetConstructor(new[] { typeof(T) });
            if (ctor1 != null)
                template = ctor1.Invoke(new[] { control });

            // non generic constructor
            var ctor2 = type.GetConstructor(new[] { typeof(Control) });
            if (ctor2 != null)
                template = ctor2.Invoke(new[] { control });

            // attempt to set control on it through generic instance
            template = Activator.CreateInstance(type);
            var baseTemplate = template as RazorControlTemplate<T>;
            if (baseTemplate != null)
                baseTemplate.Control = control;

            // template at least needs to implement IRazorControlTemplate<>
            var razorTemplate = template as IRazorControlTemplate;
            if (razorTemplate == null)
                throw new RazorException("Could not retrieve template which implements IRazorControlTemplate.");

            return razorTemplate;
        }

        /// <summary>
        /// Loads and returns the template for the specified <see cref="Control"/>.
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
            where T : Control
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(template != null);

            template.Render(writer);
        }

        /// <summary>
        /// Renders the Razor template configured for the specified <see cref="Control"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="Control"/>.Render method.
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
        /// Renders the Razor template configured for the specified <see cref="Control"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="Control"/>.Render method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="control"></param>
        public static void Render<T>(HtmlTextWriter writer, T control)
            where T : Control
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(control != null);

            var template = Template<T>(control);
            if (template == null)
                throw new RazorException("Could not locate Razor template for {0}.", typeof(T));

            template.Render(writer);
        }

        /// <summary>
        /// Renders the Razor template configured for the specified <see cref="Control"/> instance, to the specified
        /// <see cref="HtmlTextWriter"/>. This method is best invoked from the <see cref="Control"/>.Render method.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="control"></param>
        /// <param name="controlType"></param>
        public static void Render(HtmlTextWriter writer, Control control, Type controlType)
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(controlType != null);

            RenderMethod.MakeGenericMethod(controlType)
                .Invoke(null, new object[] { writer, control });
        }

    }

}
