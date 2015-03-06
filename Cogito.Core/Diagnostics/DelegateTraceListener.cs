using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Cogito.Core.Diagnostics
{

    /// <summary>
    /// Provides a <see cref="TraceListener"/> implementation that writes messages to a delegate.
    /// </summary>
    public class DelegateTraceListener :
        TraceListener
    {

        Action<string> _write;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="write"></param>
        public DelegateTraceListener(Action<string> write)
        {
            Contract.Requires<ArgumentNullException>(write != null);

            _write = write;
        }

        public override void Write(string message)
        {
            _write(message);
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }

    }

}
