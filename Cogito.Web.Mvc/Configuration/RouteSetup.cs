using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Reflection;
using System.Web.Mvc;

using Cogito.Application.Lifecycle;
using Cogito.Composition;

namespace Cogito.Web.Mvc.Configuration
{

    [OnStart(typeof(IMvcModule))]
    public class RouteSetup : MvcLifecycleListener
    {

        ICompositionContext composition;
        IMvcModule module;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="module"></param>
        [ImportingConstructor]
        public RouteSetup(
            ICompositionContext composition,
            IMvcModule module)
            : base()
        {
            this.composition = composition;
            this.module = module;
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
            module.Routes.MapMvcAttributeRoutes(t);
        }

    }

}
