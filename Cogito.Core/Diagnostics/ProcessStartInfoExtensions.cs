using System.Diagnostics;
using System.Threading.Tasks;

namespace Cogito.Diagnostics
{

    public static class ProcessStartInfoExtensions
    {

        /// <summary>
        /// Starts the given <see cref="ProcessStartInfo"/> and returns a task that results in the exit code.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Task<int> StartAndWaitAsync(this ProcessStartInfo info)
        {
            return Task.Run(() =>
            {
                var p = Process.Start(info);
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
