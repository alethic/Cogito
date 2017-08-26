using System;
using System.Diagnostics;

namespace Cogito.Diagnostics
{

    /// <summary>
    /// Provides a <see cref="TraceListener"/> implementation that writes messages to a delegate.
    /// </summary>
    public class DelegateTraceListener :
        TraceListener
    {

        readonly Action<string> _write;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="write"></param>
        public DelegateTraceListener(Action<string> write)
        {
            if (write == null)
                throw new ArgumentNullException(nameof(write));

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
