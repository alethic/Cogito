using System;

using Cogito.Negotiation.Tests.Negotiators;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Negotiation.Tests
{

    [TestClass]
    public class DijkstraAlgorithmTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            // start at a and end at d
            var a = Negotiator.Terminate<StateA>();
            var b = Negotiator.Terminate<StateD>();

            var g = new MergedNegotiationGraph(
                new DefaultNegotiationGraph(
                    new INegotiatorProvider[] 
                    {
                        new DefaultNegotiatorProvider(
                            new IConnectorProvider[]
                            {
                                new StateConnectorProvider(),
                            }),
                    }),
                new [] { a, b });

            var d = new DijkstraRouter();
            var r = d.Route(g, a, b);
            foreach (var i in r)
                Console.WriteLine(i.Execute(new StateA("yay")));
        }

    }

}
