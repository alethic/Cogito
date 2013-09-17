using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Web.Mvc;
using System.Linq;
using Cogito.Application.Lifecycle;
using Cogito.Composition;
using System.Reflection;

namespace Cogito.Web.Mvc.Configuration
{

    [OnStart(typeof(IMvcApplication))]
    public class ControllerRouteConfiguration : MvcLifecycleComponent
    {

        ICompositionContext composition;
        IMvcApplication app;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="app"></param>
        [ImportingConstructor]
        public ControllerRouteConfiguration(
            ICompositionContext composition,
            IMvcApplication app)
            : base(app)
        {
            this.composition = composition;
            this.app = app;
        }

        public override void OnStart()
        {
            var c = composition.GetExports(new ContractBasedImportDefinition(
                AttributedModelServices.GetContractName(typeof(IController)),
                AttributedModelServices.GetTypeIdentity(typeof(IController)),
                null,
                ImportCardinality.ZeroOrMore,
                false,
                false,
                CreationPolicy.Any));

            var t = new List<Type>();

            foreach (var i in c)
            {
                var m = ReflectionModelServices.GetExportingMember(i.Definition);
                if (m.MemberType == MemberTypes.TypeInfo)
                    foreach (var a in m.GetAccessors())
                        if (a is Type)
                            t.Add((Type)a);
            }

            // map the attributed routes
            app.Routes.MapMvcAttributeRoutes(t);
        }

    }

}
