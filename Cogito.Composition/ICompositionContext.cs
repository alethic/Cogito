using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides an abstraction around the MEF composition container, exposing convenience methods to parts. 
    /// </summary>
    public interface ICompositionContext : System.ComponentModel.Composition.ICompositionService, IDisposable
    {

        /// <summary>
        /// Executes the given <see cref="CompositionBatch"/> in the service.
        /// </summary>
        /// <param name="batch"></param>
        void Compose(CompositionBatch batch);

        /// <summary>
        /// Queries the <see cref="ICompositionContext"/> for exports which match the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        IEnumerable<Export> GetExports(ImportDefinition definition);

        /// <summary>
        /// Creates a new composition scope.
        /// </summary>
        /// <returns></returns>
        ICompositionContext BeginScope();

        /// <summary>
        /// Registers the given <see cref="ComposablePartCatalog"/> with the service.
        /// </summary>
        /// <param name="catalog"></param>
        void Register(ComposablePartCatalog catalog);

    }

}
