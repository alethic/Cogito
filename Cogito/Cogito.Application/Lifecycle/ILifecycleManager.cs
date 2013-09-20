using System;

namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Provides methods to invoke lifecycle events.
    /// </summary>
    public interface ILifecycleManager<out T>
        where T : IApplication
    {

        /// <summary>
        /// Changes the state of the application to Init, possibly executing tasks.
        /// </summary>
        void Init();

        /// <summary>
        /// Changes the state of the application to BeforeStart, possibly executing tasks.
        /// </summary>
        void BeforeStart();

        /// <summary>
        /// Changes the state of the application to Start, possibly executing tasks.
        /// </summary>
        void Start();

        /// <summary>
        /// Changes the state of the application to AfterStart, possibly executing tasks.
        /// </summary>
        void AfterStart();

        /// <summary>
        /// Changes the state of the application to BeforeShutdown, possibly executing tasks.
        /// </summary>
        void BeforeShutdown();

        /// <summary>
        /// Changes the state of the application to Shutdown, possibly executing tasks.
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Advances the state to the specified position.
        /// </summary>
        /// <param name="state"></param>
        void EnsureState(State state);

        /// <summary>
        /// Raised when the state of the application is changed.
        /// </summary>
        event EventHandler<StateChangedEventArgs> StateChanged;

    }

}
