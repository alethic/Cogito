using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Writes messages to a foreign <see cref="AppDomain"/>.
    /// </summary>
    public class AppDomainTraceListener :
        TraceListener
    {

        AppDomainTraceReceiver receiver;

        /// <summary>
        /// Adds ourselves to the <see cref="Trace"/> Listeners collection.
        /// </summary>
        /// <param name="receiver"></param>
        internal void ForwardTo(AppDomainTraceReceiver receiver)
        {
            Contract.Requires<ArgumentNullException>(receiver != null);

            // relay messages through this remote object
            this.receiver = receiver;

            // listen for new trace messages
            Trace.Listeners.Add(this);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public override void Write(string message)
        {
            receiver.Write(message);
        }

        public override void WriteLine(string message)
        {
            receiver.WriteLine(message);
        }

    }

}
