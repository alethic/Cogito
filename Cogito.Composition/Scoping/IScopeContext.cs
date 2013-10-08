using System.ComponentModel.Composition;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Provides scopes of the given instance type.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    [InheritedExport(typeof(IScopeContext<>))]
    public interface IScopeContext<TScope> : IScopeContext
    {

        /// <summary>
        /// Finds a composition context for the current scope of type <typeparamref name="TScope"/>.
        /// </summary>
        /// <returns></returns>
        ICompositionContext GetScope();

        /// <summary>
        /// Begins a new scope of type <typeparamref name="TScope"/>.
        /// </summary>
        /// <returns></returns>
        ICompositionContext BeginScope();

    }

    /// <summary>
    /// Provides scopes.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public interface IScopeContext
    {

        /// <summary>
        /// Finds a composition context for the current scope of the proper type.
        /// </summary>
        /// <returns></returns>
        ICompositionContext GetScope();

        /// <summary>
        /// Begins a new scope of the proper type.
        /// </summary>
        /// <returns></returns>
        ICompositionContext BeginScope();

    }

}
