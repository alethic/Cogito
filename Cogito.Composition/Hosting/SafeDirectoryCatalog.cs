using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cogito.Composition.Hosting
{

    public class SafeDirectoryCatalog :
        ComposablePartCatalog
    {

        readonly AggregateCatalog catalog;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path"></param>
        public SafeDirectoryCatalog(string path)
            : this(path, "*.dll", null)
        {
            Contract.Requires<ArgumentNullException>(path != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        public SafeDirectoryCatalog(string path, string pattern)
            : this(path, pattern, null)
        {
            Contract.Requires<ArgumentNullException>(path != null);
            Contract.Requires<ArgumentNullException>(pattern != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        /// <param name="reflectionContext"></param>
        public SafeDirectoryCatalog(string path, string pattern, ReflectionContext reflectionContext)
        {
            Contract.Requires<ArgumentNullException>(path != null);
            Contract.Requires<ArgumentNullException>(pattern != null);

            var files = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);

            catalog = new AggregateCatalog();

            foreach (var file in files)
            {
                try
                {
                    var asmCat = new AssemblyCatalog(file);
                    if (asmCat.Parts.ToList().Count > 0)
                        catalog.Catalogs.Add(asmCat);
                }
                catch (ReflectionTypeLoadException)
                {

                }
                catch (BadImageFormatException)
                {

                }
            }
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return catalog.Parts; }
        }

    }

}
