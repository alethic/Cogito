using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Provides methods for interacting with the composition framework.
    /// </summary>
    public interface ICompositionService : System.ComponentModel.Composition.ICompositionService, IDisposable
    {

        /// <summary>
        /// Executes the given <see cref="CompositionBatch"/> in the service.
        /// </summary>
        /// <param name="batch"></param>
        void Compose(CompositionBatch batch);

        /// <summary>
        /// Queries the <see cref="ICompositionService"/> for exports which match the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        IEnumerable<Export> GetExports(ImportDefinition definition);

        /// <summary>
        /// Creates a new composition scope.
        /// </summary>
        /// <returns></returns>
        ICompositionService CreateScope();

        /// <summary>
        /// Registers the given <see cref="ComposablePartCatalog"/> with the service.
        /// </summary>
        /// <param name="catalog"></param>
        void Register(ComposablePartCatalog catalog);

    }

}
