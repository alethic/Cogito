using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Resources
{

    /// <summary>
    /// Describes a resource being added to a <see cref="ResourceBundle"/>.
    /// </summary>
    public class Resource
        : IResource
    {

        readonly IResourceBundle bundle;
        readonly string name;
        readonly string contentType;
        readonly CultureInfo cultureInfo;
        readonly bool? isDebug;
        readonly Func<object> source;
        readonly IQueryable<Expression<Func<IResourceBundle, bool>>> dependencies;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="isDebug"></param>
        /// <param name="source"></param>
        /// <param name="dependencies"></param>
        public Resource(
            IResourceBundle bundle,
            string name,
            string contentType,
            CultureInfo cultureInfo,
            bool? isDebug,
            Func<object> source,
            IQueryable<Expression<Func<IResourceBundle, bool>>> dependencies)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);

            this.bundle = bundle;
            this.name = name;
            this.contentType = contentType;
            this.cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
            this.isDebug = isDebug;
            this.source = source;
            this.dependencies = dependencies ?? Enumerable.Empty<Expression<Func<IResourceBundle, bool>>>().AsQueryable();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="isDebug"></param>
        /// <param name="source"></param>
        /// <param name="dependencies"></param>
        public Resource(
            IResourceBundle bundle,
            string name,
            string contentType,
            CultureInfo cultureInfo,
            bool? isDebug,
            Func<object> source,
            IEnumerable<Expression<Func<IResourceBundle, bool>>> dependencies)
            : this(
                bundle,
                name,
                contentType,
                cultureInfo,
                isDebug,
                source,
                dependencies != null ? dependencies.AsQueryable() : null)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="source"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="isDebug"></param>
        /// <param name="dependencies"></param>
        public Resource(
            IResourceBundle bundle,
            string name,
            string contentType,
            Func<object> source,
            CultureInfo cultureInfo = null,
            bool? isDebug = null,
            IEnumerable<Expression<Func<IResourceBundle, bool>>> dependencies = null)
            : this(
                bundle,
                name,
                contentType,
                cultureInfo,
                isDebug,
                source,
                dependencies != null ? dependencies.AsQueryable() : null)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="source"></param>
        public Resource(
            IResourceBundle bundle,
            string name,
            string contentType,
            Func<object> source)
            : this(
                bundle,
                name,
                contentType,
                null,
                null,
                source,
                null)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);
        }

        public IResourceBundle Bundle
        {
            get { return bundle; }
        }

        public string Name
        {
            get { return name; }
        }

        public string ContentType
        {
            get { return contentType; }
        }

        public CultureInfo CultureInfo
        {
            get { return cultureInfo; }
        }

        public bool? IsDebug
        {
            get { return isDebug; }
        }

        public IEnumerable<Expression<Func<IResourceBundle, bool>>> Dependencies
        {
            get { return dependencies; }
        }

        public Func<object> Source
        {
            get { return source; }
        }

        IResourceBundle IResource.Bundle
        {
            get { return Bundle; }
        }

    }

}
