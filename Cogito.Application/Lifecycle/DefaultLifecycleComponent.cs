using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Lifecycle component that participates in the lifecycle for any application type. This is needed so that any
    /// lifecycle state change results in a lifecycle state change for the base <see cref="IApplication"/> type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(IOnInit<>))]
    [Export(typeof(IOnBeforeStart<>))]
    [Export(typeof(IOnStart<>))]
    [Export(typeof(IOnAfterStart<>))]
    [Export(typeof(IOnBeforeShutdown<>))]
    [Export(typeof(IOnShutdown<>))]
    public class DefaultLifecycleComponent<T> : 
        LifecycleComponent<T>
        where T : IApplication
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DefaultLifecycleComponent()
            : base(() => true)
        {

        }

    }

}
