using System;
using System.ComponentModel.Composition;
using System.Threading;

namespace Cogito.Components.Server.TestApp
{

    [Export(typeof(IComponent))]
    public class TestTimer1 :
        Cogito.Components.Timer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TestTimer1()
            : base(interval: TimeSpan.FromSeconds(5))
        {

        }

        protected override void OnElapsed(CancellationToken cancellationToken)
        {
            Console.WriteLine("TestTimer1 invoked");
        }

    }

}
