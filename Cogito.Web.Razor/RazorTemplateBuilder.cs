using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Razor;
using System.Web.Razor.Generator;
using Cogito.CodeDom.Compiler;
using Cogito.Collections;
using Cogito.Linq;
using Cogito.Reflection;
using Cogito.Text;
using Cogito.Web.Internal;
using Microsoft.CSharp;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Provides for the ability to generate template instances from Razor code.
    /// </summary>
    public static class RazorTemplateBuilder
    {

        const string DEFAULT_TYPE_NAMESPACE = "Cogito.Web.Razor.DynamicTemplates";
        const string DEFAULT_TYPE_NAME = "__Template";
        static readonly Type DEFAULT_BASE_CLASS = typeof(RazorTemplate);
        static readonly Type DEFAULT_INNER_TEMPLATE_CLASS = typeof(HelperResult);

        /// <summary>
        /// Resolves a C# explicit reference to the member.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        static string GetCSharpMemberExpression(MemberInfo member)
        {
            Contract.Requires<ArgumentNullException>(member != null);
            return string.Format("(({0})this).{1}", member.DeclaringType.FullName, member.Name);
        }

        static readonly string writeMethod = "Write";
        static readonly string writeToMethod = "WriteTo";
        static readonly string writeLiteralMethod = "WriteLiteral";
        static readonly string writeLiteralToMethod = "WriteLiteralTo";
        static readonly string writeAttributeMethod = "WriteAttribute";
        static readonly string writeAttributeToMethod = "WriteAttributeTo";
        static readonly string layoutProperty = "Layout";
        static readonly string defineSectionMethod = "DefineSection";
        static readonly string beginContextMethod = "BeginContext";
        static readonly string endContextMethod = "EndContext";

        static readonly CSharpCodeProvider codeProvider =
            new CSharpCodeProvider();

        static readonly ConcurrentDictionary<string, Assembly> assemblyCache =
            new ConcurrentDictionary<string, Assembly>();

        static readonly ConcurrentDictionary<string, Type> typeCache =
            new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// Set of assemblies which are always referenced.
        /// </summary>
        static readonly IEnumerable<string> requiredAssemblies = Enumerable.Empty<Assembly>()
            .Append(typeof(RazorTemplateBuilder).Assembly)
            .Append(typeof(object).Assembly)
            .Append(typeof(Uri).Assembly)
            .Append(typeof(Enumerable).Assembly)
            .Select(i => i.LoadAllReferencedAssemblies())
            .SelectMany(i => i)
            .Select(i => new Uri(i.Location).LocalPath)
            .Distinct()
            .ToArray();

        /// <summary>
        /// Set of namespaces which are always referenced.
        /// </summary>
        static readonly string[] requiredNamespaces = new[] 
        {
            "System",
            "System.Collections.Generic",
            "System.Linq",
        };

        /// <summary>
        /// Loads all of the given <see cref="Assembly"/>s by name.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        static IEnumerable<string> ToLocalPaths(IEnumerable<string> assemblies)
        {
            // transform assemblies to local paths
            return assemblies
                .Select(i => new Uri(i))
                .Select(i => i.LocalPath)
                .Distinct()
                .OrderBy(i => i)
                .Tee();
        }

        /// <summary>
        /// Loads the set of <see cref="Assembly"/>s.
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        static IEnumerable<Assembly> ReflectionOnlyLoadAssemblies(IEnumerable<string> assemblies)
        {
            return ToLocalPaths(assemblies)
                .Select(i => Assembly.ReflectionOnlyLoadFrom(i));
        }

        /// <summary>
        /// Appends additional information to the code.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        static string AugmentCodeCore(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<string>() != null);

            var builder = new StringBuilder(source().ReadToEnd())
                .AppendLine()
                .AppendLine("@**")
                .Append(" * ").Append(typeof(RazorTemplateBuilder).AssemblyQualifiedName).AppendLine()
                .Append(" * ").Append(host.GetType().AssemblyQualifiedName).AppendLine();

            if (defaultNamespace != null)
                builder.Append(" * ").AppendLine(defaultNamespace);

            if (defaultClassName != null)
                builder.Append(" * ").AppendLine(defaultClassName);

            if (defaultBaseClass != null)
                builder.Append(" * ").AppendLine(defaultBaseClass.AssemblyQualifiedName);

            if (innerTemplateType != null)
                builder.Append(" * ").AppendLine(innerTemplateType.AssemblyQualifiedName);

            builder
                .AppendManyLines(importedNamespaces, " * ")
                .AppendManyLines(referencedAssemblies, " * ")
                .AppendLine(" *@")
                .ToString();

            return builder.ToString();
        }

        /// <summary>
        /// Appends the various parameters to the end of the code to assist in debugging it later.
        /// </summary>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        static Func<TextReader> AugmentCode(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Ensures(Contract.Result<Func<TextReader>>() != null);

            // replace 
            return () =>
                new StringReader(AugmentCodeCore(
                    source,
                    defaultNamespace,
                    defaultClassName,
                    defaultBaseClass,
                    referencedAssemblies,
                    importedNamespaces,
                    innerTemplateType,
                    host));
        }

        /// <summary>
        /// Ensures all of the various optional parameters are populated with the proper default values.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceCodeReader"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="innerTemplateClass"></param>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        static void CheckParameters(
            ref Func<TextReader> source,
            ref string defaultNamespace,
            ref string defaultClassName,
            ref Type defaultBaseClass,
            ref IEnumerable<string> referencedAssemblies,
            ref IEnumerable<string> importedNamespaces,
            ref Type innerTemplateClass,
            ref RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            // check for Execute method
            if (defaultBaseClass != null)
            {
                var executeMethod = defaultBaseClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(i => i.Name == "Execute")
                    .Where(i => i.IsPublic || i.IsFamily)
                    .Where(i => i.IsVirtual || i.IsAbstract)
                    .Where(i => !i.IsGenericMethod && !i.IsGenericMethodDefinition)
                    .FirstOrDefault();
                if (executeMethod == null)
                    throw new RazorException("Template must have a method named Execute capable of being overridden in a derived class.");
            }

            // ensure required assemblies are referenced
            referencedAssemblies = new HashSet<string>(requiredAssemblies)
                .ThenUnionWith(referencedAssemblies ?? Enumerable.Empty<string>());

            // ensure required namespaces are added
            importedNamespaces = new HashSet<string>(requiredNamespaces)
                .ThenUnionWith(importedNamespaces ?? Enumerable.Empty<string>());

            // default host implementation
            if (host == null)
                host = new RazorHost();

            // specified default class information
            if (defaultNamespace != null)
                host.DefaultNamespace = defaultNamespace;
            if (defaultClassName != null)
                host.DefaultClassName = defaultClassName;
            if (defaultBaseClass != null)
                host.DefaultBaseClass = defaultBaseClass.FullName;

            // fall back values
            if (host.DefaultNamespace == null)
                host.DefaultNamespace = DEFAULT_TYPE_NAMESPACE;
            if (host.DefaultClassName == null)
                host.DefaultClassName = DEFAULT_TYPE_NAME;
            if (host.DefaultBaseClass == null)
                host.DefaultBaseClass = DEFAULT_BASE_CLASS.FullName;

            // replace the source with an augmented server that includes unique information
            source = AugmentCode(
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblies,
                importedNamespaces,
                innerTemplateClass,
                host);
        }

        /// <summary>
        /// Ensures all of the various optional parameters are populated with the proper default values.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="cacheKey"></param>
        static void CheckParameters(
            ref Func<TextReader> source,
            ref string defaultNamespace,
            ref string defaultClassName,
            ref Type defaultBaseClass,
            ref IEnumerable<string> referencedAssemblies,
            ref IEnumerable<string> importedNamespaces,
            ref Type innerTemplateType,
            ref string cacheKey,
            ref RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            CheckParameters(
                ref source,
                ref defaultNamespace,
                ref defaultClassName,
                ref defaultBaseClass,
                ref referencedAssemblies,
                ref importedNamespaces,
                ref innerTemplateType,
                ref host);

            // and we use the augmented source as the cache key itself
            if (cacheKey == null)
                cacheKey = source().ReadToEnd();
        }

        /// <summary>
        /// Initializes a new instance of the Razor engine.
        /// </summary>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        static RazorTemplateEngine CreateTemplateEngine(
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<RazorTemplateEngine>() != null);

            // required portions of template implementation
            var ctx = new GeneratedClassContext(
                "Execute",
                writeMethod,
                writeLiteralMethod,
                writeToMethod,
                writeLiteralToMethod,
                innerTemplateType != null ? innerTemplateType.FullName : typeof(HelperResult).FullName,
                defineSectionMethod,
                beginContextMethod,
                endContextMethod);
            ctx.WriteAttributeMethodName = writeAttributeMethod;
            ctx.WriteAttributeToMethodName = writeAttributeToMethod;
            ctx.LayoutPropertyName = layoutProperty;

            // configure host
            host.GeneratedClassContext = ctx;
            if (importedNamespaces != null)
                host.NamespaceImports.UnionWith(importedNamespaces);
            return new RazorTemplateEngine(host);
        }

        /// <summary>
        /// Parses the template with Razor.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        static GeneratorResults RazorGenerate(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<GeneratorResults>() != null);

            // initialize Razor
            var engine = CreateTemplateEngine(
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                importedNamespaces,
                innerTemplateType,
                host);

            // parse template into code unit
            var result = engine.GenerateCode(source());

            // check for errors
            if (result.ParserErrors.Count > 0)
                throw new ParserErrorException(result, source());

            // find generated type and imports
            var typeDeclaration = result.GeneratedCode.Namespaces
                .Cast<CodeNamespace>()
                .Select(i => new
                {
                    Namespaces = i.Imports.Cast<CodeNamespaceImport>().Select(j => j.Namespace),
                    Type = i.Types.Cast<CodeTypeDeclaration>().First(),
                })
                .FirstOrDefault();
            if (typeDeclaration == null)
                throw new NullReferenceException("Could not find generated type.");

            // remove existing ctors
            foreach (var ctor in typeDeclaration.Type.Members.OfType<CodeConstructor>().ToList())
                typeDeclaration.Type.Members.Remove(ctor);

            // extract current constructors, and base types
            var bases = typeDeclaration.Type.BaseTypes.Cast<CodeTypeReference>().Select(i => i.BaseType);

            // resolve base types for base class
            var btype = bases
                .Select(i => CSharpTypeNameResolver.ResolveType(
                    i, 
                    ReflectionOnlyLoadAssemblies(referencedAssemblies).ToList(), 
                    typeDeclaration.Namespaces))
                .Where(i => i.IsClass)
                .FirstOrDefault();
            if (btype == null)
                throw new NullReferenceException("Cannot resolve base type.");

            foreach (var bctor in btype.GetConstructors())
            {
                if (bctor.IsPublic ||
                    bctor.IsFamily ||
                    bctor.IsFamilyOrAssembly)
                {
                    // generate public ctor
                    var ctor = new CodeConstructor();
                    ctor.Attributes = (ctor.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
                    typeDeclaration.Type.Members.Add(ctor);

                    // populate parameters
                    foreach (var p in bctor.GetParameters())
                        ctor.Parameters.Add(new CodeParameterDeclarationExpression(p.ParameterType, p.Name));

                    // invoke base parameters
                    foreach (var p in bctor.GetParameters())
                        ctor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(p.Name));
                }
            }

            return result;
        }

        /// <summary>
        /// Parses a Razor template into a C# code class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        static CodeCompileUnit Generate(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null); ;
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<CodeCompileUnit>() != null);

            return RazorGenerate(
                    source,
                    defaultNamespace,
                    defaultClassName,
                    defaultBaseClass,
                    referencedAssemblies,
                    importedNamespaces,
                    innerTemplateType,
                    host)
                .GeneratedCode;
        }

        /// <summary>
        /// Parses a Razor template and writes the code file to <paramref name="writer"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="writer"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="cacheKey"></param>
        /// <param name="host"></param>
        public static void WriteTo(
            TextWriter writer,
            Func<TextReader> source,
            string defaultNamespace = null,
            string defaultClassName = null,
            Type defaultBaseClass = null,
            IEnumerable<string> referencedAssemblies = null,
            IEnumerable<string> importedNamespaces = null,
            Type innerTemplateType = null,
            string cacheKey = null,
            RazorEngineHost host = null)
        {
            Contract.Requires<ArgumentNullException>(writer != null);
            Contract.Requires<ArgumentNullException>(source != null);

            // fix up parameters
            CheckParameters(
                ref source,
                ref defaultNamespace,
                ref defaultClassName,
                ref defaultBaseClass,
                ref referencedAssemblies,
                ref importedNamespaces,
                ref innerTemplateType,
                ref cacheKey,
                ref host);

            // parse the template and generate compile unit
            var codeUnit = Generate(
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblies,
                importedNamespaces,
                innerTemplateType,
                host);

            // generate code
            codeProvider.GenerateCodeFromCompileUnit(codeUnit, writer, new CodeGeneratorOptions());
        }

        /// <summary>
        /// Parses a Razor template, generates and returns C# code.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="templateType"></param>
        /// <returns></returns>
        public static string ToCode(
            Func<TextReader> source,
            string defaultNamespace = null,
            string defaultClassName = null,
            Type defaultBaseClass = null,
            IEnumerable<string> referencedAssemblies = null,
            IEnumerable<string> importedNamespaces = null,
            Type innerTemplateType = null,
            string cacheKey = null,
            RazorEngineHost host = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Ensures(Contract.Result<string>() != null);

            // fix up parameters
            CheckParameters(
                ref source,
                ref defaultNamespace,
                ref defaultClassName,
                ref defaultBaseClass,
                ref referencedAssemblies,
                ref importedNamespaces,
                ref innerTemplateType,
                ref cacheKey,
                ref host);

            // output code as text
            var writer = new StringWriter();
            WriteTo(
                writer,
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblies,
                importedNamespaces,
                innerTemplateType,
                cacheKey,
                host);

            return writer.ToString();
        }

        /// <summary>
        /// Compiles the given code unit.
        /// </summary>
        /// <param name="codeUnit"></param>
        /// <param name="referencedAssemblies"></param>
        /// <returns></returns>
        static Assembly Compile(
            CodeCompileUnit codeUnit,
            IEnumerable<string> referencedAssemblies)
        {
            Contract.Requires<ArgumentNullException>(codeUnit != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Ensures(Contract.Result<Assembly>() != null);

            // configure compiler and add additional references
            var outputAssemblyName = Path.GetTempPath() + Guid.NewGuid().ToString("N") + ".dll";
            var compilerParameters = new CompilerParameters(ToLocalPaths(referencedAssemblies).ToArray(), outputAssemblyName);
            compilerParameters.GenerateInMemory = true;

#if DEBUG
            compilerParameters.IncludeDebugInformation = true;
#endif

            // begin compilation
            var compilerResults = codeProvider.CompileAssemblyFromDom(compilerParameters, codeUnit);
            if (compilerResults.Errors.Count > 0)
                throw new CompilerErrorException(compilerResults.Errors,
                    codeProvider.GenerateCodeFromCompileUnit(codeUnit, new CodeGeneratorOptions()));

            return compilerResults.CompiledAssembly;
        }

        /// <summary>
        /// Parses and compiles the template into an assembly.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="innerTemplateType"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        static Assembly BuildAssembly(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<Assembly>() != null);

            // generate initial code from Razor template
            var codeUnit = Generate(
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblies,
                importedNamespaces,
                innerTemplateType,
                host);

            // compile into new assembly
            return Compile(
                codeUnit,
                referencedAssemblies);
        }

        /// <summary>
        /// Parses and compiles the template into an assembly and returns the newly generated type.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <returns></returns>
        static Type BuildType(
            Func<TextReader> source,
            string defaultNamespace,
            string defaultClassName,
            Type defaultBaseClass,
            IEnumerable<string> referencedAssemblies,
            IEnumerable<string> importedNamespaces,
            Type innerTemplateType,
            RazorEngineHost host)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);
            Contract.Requires<ArgumentNullException>(importedNamespaces != null);
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Ensures(Contract.Result<Type>() != null);

            // build new assembly
            var assembly = BuildAssembly(
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblies,
                importedNamespaces,
                innerTemplateType,
                host);

            // return type from assembly
            return assembly.GetTypes()
                .Where(i => typeof(IRazorTemplate).IsAssignableFrom(i))
                .FirstOrDefault();
        }

        /// <summary>
        /// Parses and compiles the template into an assembly and returns the newly generated type.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static Type GetOrBuildType(
            Func<TextReader> source,
            string defaultNamespace = null,
            string defaultClassName = null,
            Type defaultBaseClass = null,
            IEnumerable<string> referencedAssemblies = null,
            IEnumerable<string> importedNamespaces = null,
            Type innerTemplateType = null,
            string cacheKey = null,
            RazorEngineHost host = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Ensures(Contract.Result<Type>() != null);

            // fix up parameters
            CheckParameters(
                ref source,
                ref defaultNamespace,
                ref defaultClassName,
                ref defaultBaseClass,
                ref referencedAssemblies,
                ref importedNamespaces,
                ref innerTemplateType,
                ref cacheKey,
                ref host);

            return typeCache.GetOrAdd(cacheKey, _ =>
                BuildType(
                    source,
                    defaultNamespace,
                    defaultClassName,
                    defaultBaseClass,
                    referencedAssemblies,
                    importedNamespaces,
                    innerTemplateType,
                    host));
        }

        /// <summary>
        /// Parses and compiles the template into an assembly and returns the newly generated type.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultNamespace"></param>
        /// <param name="defaultClassName"></param>
        /// <param name="defaultBaseClass"></param>
        /// <param name="referencedAssemblies"></param>
        /// <param name="importedNamespaces"></param>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static Type GetOrBuildType(
            Func<TextReader> source,
            string defaultNamespace = null,
            string defaultClassName = null,
            Type defaultBaseClass = null,
            IEnumerable<Assembly> referencedAssemblies = null,
            IEnumerable<string> importedNamespaces = null,
            Type innerTemplateType = null,
            string cacheKey = null,
            RazorEngineHost host = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Ensures(Contract.Result<Type>() != null);

            // convert assemblies to location of assemblies
            var referencedAssemblyLocations = referencedAssemblies
                .Select(i => i.Location);

            return GetOrBuildType(
                source,
                defaultNamespace,
                defaultClassName,
                defaultBaseClass,
                referencedAssemblyLocations,
                importedNamespaces,
                innerTemplateType,
                cacheKey,
                host);
        }

    }

}
