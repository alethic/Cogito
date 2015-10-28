using System;
using System.ComponentModel.Composition;
using System.Threading;

namespace Cogito.Components.Server.TestApp
{

    [Export(typeof(IComponent))]
    public class TestTimer :
        Cogito.Components.Timer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TestTimer()
            : base(interval: TimeSpan.FromSeconds(10))
        {

        }

        protected override void OnTimer(CancellationToken cancellationToken)
        {
            Console.WriteLine("TestTimer invoked");
        }

    }

}
