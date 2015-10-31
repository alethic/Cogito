using System;
using System.ComponentModel.Composition;
using System.Threading;

namespace Cogito.Components.Server.TestApp
{

    [Export(typeof(IComponent))]
    public class TestTimer2 :
        Cogito.Components.Timer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TestTimer2()
            : base(interval: TimeSpan.FromSeconds(10))
        {

        }

        protected override void OnElapsed(CancellationToken cancellationToken)
        {
            Console.WriteLine("TestTimer2 invoked");
        }

    }

}
