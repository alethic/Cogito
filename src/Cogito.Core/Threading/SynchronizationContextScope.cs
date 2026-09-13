using System;
using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// Introduces a <see cref="SynchronizationContext"/> within the descending scope and restores it upon dispose.
    /// </summary>
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

        /// <summary>
        /// Resets the scope.
        /// </summary>
        public void Dispose()
        {
            SynchronizationContext.SetSynchronizationContext(prev);
        }

    }

}
