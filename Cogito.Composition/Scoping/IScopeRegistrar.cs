using System.ComponentModel.Composition;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Provides registration for known scopes.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    [InheritedExport(typeof(IScopeRegistrar<>))]
    public interface IScopeRegistrar<TScope> :
        IScopeRegistrar
    {



    }

    /// <summary>
    /// Provides registration for known scopes.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public interface IScopeRegistrar
    {

        /// <summary>
        /// Finds a composition context for the current scope of the proper type.
        /// </summary>
        /// <returns></returns>
        ICompositionContext GetScope();

        /// <summary>
        /// Sets a new scope of the proper type.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        void RegisterScope(ICompositionContext context);

    }

}
