using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Diagnostics
{

    /// <summary>
    /// Provides various extension methods for working with <see cref="ProcessStartInfo"/> instances.
    /// </summary>
    public static class ProcessStartInfoExtensions
    {

        /// <summary>
        /// Starts the given <see cref="ProcessStartInfo"/> and returns a task that results in the exit code.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static Task<int> StartAndWaitForExitAsync(this ProcessStartInfo info, TimeSpan? timeout = null)
        {
            Contract.Requires<ArgumentNullException>(info != null);

            return Task.Run(() =>
            {
                var p = Process.Start(info);
                if (timeout != null)
                    p.WaitForExit((int)timeout.Value.TotalMilliseconds);
                else
                    p.WaitForExit();
                return p;
            })
            .ContinueWith(p =>
            {
                return p.Result.ExitCode;
            });
        }

    }

}
