using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Cogito.Resources
{

    /// <summary>
    /// Represents a resource in an <see cref="Assembly"/>.
    /// </summary>
    public class AssemblyResource :
        Resource
    {

        static readonly ConcurrentDictionary<Tuple<Assembly, string>, string> contentTypeCache =
            new ConcurrentDictionary<Tuple<Assembly, string>, string>();

        static string PeriodSuffix(string value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            if (!value.EndsWith("."))
                value = value + ".";

            return value;
        }

        /// <summary>
        /// Gets the appropriate name for the given resource within the <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        static string GetResourceName(Assembly assembly, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            var name = resourceName;
            var assemblyName = assembly.GetName().Name;
            var bundleAttrs = assembly.GetCustomAttributes<AssemblyResourceBundleAttribute>();
            var resourceAttrs = assembly.GetCustomAttributes<AssemblyResourceAttribute>();
            var pathAttrs = assembly.GetCustomAttributes<AssemblyResourcePathAttribute>();

            // value to strip from resource name
            var strip = bundleAttrs
                .OrderByDescending(i => i.Prefix.Length)
                .Select(i => i.Prefix)
                .Where(i => name.StartsWith(i))
                .FirstOrDefault();

            // we should strip assembly name if all resources are prefixed with it
            if (strip == null && assembly.GetManifestResourceNames().All(i => i.StartsWith(assemblyName)))
                strip = assemblyName;

            if (strip != null && name.StartsWith(PeriodSuffix(strip)))
                if (name.Remove(0, PeriodSuffix(strip).Length).Contains('.'))
                    name = name.Remove(0, PeriodSuffix(strip).Length);

            // trim off leading or trailing '.'
            name = name.Trim('.');

            // find common namespace prefix to build pathed name
            var namespacePrefix = assembly.GetTypes()
                .Select(i => i.Namespace)
                .Concat(pathAttrs.Select(i => i.Path))
                .Where(i => i != null && i != "")
                .Where(i => resourceName.StartsWith(i))
                .Distinct()
                .OrderByDescending(i => i.Length)
                .Where(i => PeriodSuffix(i).StartsWith(PeriodSuffix(strip)))
                .Select(i => PeriodSuffix(i).Remove(0, strip.Length + 1))
                .Where(i => i != "")
                .FirstOrDefault();
            if (namespacePrefix != null)
                name = name.Replace(namespacePrefix, namespacePrefix.Replace('.', '/'));

            return name;
        }

        /// <summary>
        /// Gets the content type recorded for the given <see cref="Assembly"/> resource.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <param name="mediaTypeResolver"></param>
        /// <returns></returns>
        static string GetContentType(Assembly assembly, string resourceName, IMediaTypeResolver mediaTypeResolver)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(mediaTypeResolver != null);

            return contentTypeCache.GetOrAdd(Tuple.Create(assembly, resourceName), _ =>
            {
                return assembly.GetCustomAttributes<AssemblyResourceAttribute>()
                    .Where(i => i.ResourceName == resourceName)
                    .Select(i => i.ContentType)
                    .FirstOrDefault() ?? (string)mediaTypeResolver.Resolve(resourceName);
            });
        }

        readonly AssemblyResourceBundle bundle;
        readonly string resourceName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <param name="contentType"></param>
        public AssemblyResource(
            AssemblyResourceBundle bundle,
            Type type,
            string resourceName,
            string contentType)
            : base(
                bundle,
                GetResourceName(bundle.Assembly, resourceName),
                contentType,
                CultureInfo.InvariantCulture,
                null,
                () => type.Assembly.GetManifestResourceStream(type, resourceName),
                bundle.LastModifiedTimeUtc,
                null)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(contentType != null);

            this.bundle = bundle;
            this.resourceName = resourceName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="type"></param>
        /// <param name="contentType"></param>
        public AssemblyResource(
            AssemblyResourceBundle bundle,
            Version version,
            Type type,
            string contentType)
            : this(
                bundle,
                type,
                type.Name,
                contentType)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="namespaceName"></param>
        /// <param name="resourceName"></param>
        /// <param name="contentType"></param>
        public AssemblyResource(
            AssemblyResourceBundle bundle,
            string resourceName,
            string contentType)
            : base(
                bundle,
                GetResourceName(bundle.Assembly, resourceName),
                contentType,
                CultureInfo.InvariantCulture,
                null,
                () => bundle.Assembly.GetManifestResourceStream(resourceName),
                bundle.LastModifiedTimeUtc,
                null)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(contentType != null);

            this.bundle = bundle;
            this.resourceName = resourceName;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="resourceName"></param>
        public AssemblyResource(
            AssemblyResourceBundle bundle,
            string resourceName,
            IMediaTypeResolver mediaTypeResolver)
            : this(
                bundle,
                resourceName,
                GetContentType(bundle.Assembly, resourceName, mediaTypeResolver))
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(mediaTypeResolver != null);
        }

        /// <summary>
        /// Gets the full name of the resource.
        /// </summary>
        public string ResourceName
        {
            get { return resourceName; }
        }

    }

}
