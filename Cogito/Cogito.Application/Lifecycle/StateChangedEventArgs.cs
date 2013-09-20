using System;

namespace Cogito.Application.Lifecycle
{

    public class StateChangedEventArgs : EventArgs
    { 

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="state"></param>
        internal StateChangedEventArgs(State state)
        {
            State = state;
        }

        public State State { get; private set; }

    }

}
