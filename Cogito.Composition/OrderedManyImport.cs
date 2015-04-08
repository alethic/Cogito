using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Linq;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides a set of the specified type ordered by the order metadata.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(OrderedImportMany<>))]
    public class OrderedImportMany<T> :
        IEnumerable<T>
    {

        readonly IEnumerable<Lazy<T, IOrderedExportMetadata>> imports;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="imports"></param>
        [ImportingConstructor]
        public OrderedImportMany(
            [ImportMany] IEnumerable<Lazy<T, IOrderedExportMetadata>> imports)
        {
            Contract.Requires<ArgumentNullException>(imports != null);

            this.imports = imports.OrderBy(i => i.Metadata.Order).Tee();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return imports.Select(i => i.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
