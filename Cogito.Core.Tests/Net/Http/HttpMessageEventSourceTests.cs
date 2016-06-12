using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Http;
using Cogito.Net.Http;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
using Microsoft.Samples.Eventing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Tests.Net.Http
{

    [TestClass]
    public class HttpMessageEventSourceTests
    {

        [TestMethod]
        public void Test_EventSource()
        {
            EventSourceAnalyzer.InspectAll(HttpMessageEventSource.Current);
        }

        [TestMethod]
        public void Test_Request()
        {
            using (var session = new TraceEventSession("MyRealTimeSession"))
            {
                session.Source.Dynamic.All += data => Console.WriteLine("GOT Event " + data);
                session.EnableProvider(TraceEventProviders.GetEventSourceGuidFromName("Cogito-Net-Http-Messages"));

                HttpMessageEventSource.Current.Request(new HttpRequestMessage(HttpMethod.Get, new Uri("http://www.tempuri.com"))
                {

                });

                session.Source.Process();
            }
        }

        [TestMethod]
        public void Test_Response()
        {
            HttpMessageEventSource.Current.Response(new HttpResponseMessage(HttpStatusCode.OK));
        }

    }

}
