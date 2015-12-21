using System;
using System.Threading;

namespace Cogito.Threading
{

    public struct SynchronizationContextScope :
        IDisposable
    {

        readonly SynchronizationContext prev;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        public SynchronizationContextScope(SynchronizationContext context)
        {
            prev = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(context);
        }

        public void Dispose()
        {
            SynchronizationContext.SetSynchronizationContext(prev);
        }

    }

}
