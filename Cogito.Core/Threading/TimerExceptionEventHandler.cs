#if !NETSTANDARD1_6

namespace Cogito.Threading
{

    /// <summary>
    /// Signature of a timer exception handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void TimerExceptionEventHandler(object sender, TimerExceptionEventArgs args);

}

#endif
