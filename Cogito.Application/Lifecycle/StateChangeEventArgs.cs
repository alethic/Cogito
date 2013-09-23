using System;

namespace Cogito.Application.Lifecycle
{

    public class StateChangeEventArgs : EventArgs
    { 

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="state"></param>
        internal StateChangeEventArgs(State state)
        {
            State = state;
        }

        /// <summary>
        /// Current state.
        /// </summary>
        public State State { get; private set; }

    }

}
