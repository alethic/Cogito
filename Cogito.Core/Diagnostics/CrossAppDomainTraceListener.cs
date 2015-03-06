using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Cogito.Core.Diagnostics
{

    public class CrossAppDomainTraceListener :
        MarshalByRefObject
    {

        CrossAppDomainTraceListener parent;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CrossAppDomainTraceListener()
        {

        }

        /// <summary>
        /// Attaches to the remote diagnostics pipeline and forwards messages to the current <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="domain"></param>
        public static void ListenTo(AppDomain domain)
        {
            var listenerType = typeof(CrossAppDomainTraceListener);
            var remote = (CrossAppDomainTraceListener)domain.CreateInstanceAndUnwrap(
                listenerType.Assembly.FullName,
                listenerType.FullName);

            var local = new CrossAppDomainTraceListener();

            remote.Register(local);
        }

        /// <summary>
        /// Invoked on the remote <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="parent"></param>
        void Register(CrossAppDomainTraceListener parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            this.parent = parent;

            // append a new trace listener that invokes the local Write method
            Trace.Listeners.Add(new DelegateTraceListener(Write));
        }

        /// <summary>
        /// Invoked on the remote <see cref="AppDomain"/> to write a message.
        /// </summary>
        /// <param name="message"></param>
        void Write(string message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            parent.RemoteWrite(message);
        }

        /// <summary>
        /// Invoked on the local <see cref="AppDomain"/> to write a message.
        /// </summary>
        /// <param name="message"></param>
        void RemoteWrite(string message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            Trace.Write(message);
        }

    }

}
