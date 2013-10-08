using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.Application.Lifecycle;
using Cogito.Composition;

namespace Cogito.Web.Internal
{

    [Module(typeof(IWebModule))]
    public class WebModule : IWebModule
    {

        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(composition != null);
            Contract.Invariant(defaultConfiguration != null);
            Contract.Invariant(lifecycle != null);
        }

        ICompositionContext composition;
        IEnumerable<IWebConfiguration> defaultConfiguration;
        ILifecycleManager<IWebModule> lifecycle;
        bool configured;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public WebModule(
            ICompositionContext composition,
            [ImportMany] IEnumerable<IWebConfiguration> configurations,
            ILifecycleManager<IWebModule> lifecycle)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(configurations != null);
            Contract.Requires<ArgumentNullException>(lifecycle != null);

            this.composition = composition;
            this.defaultConfiguration = configurations;
            this.lifecycle = lifecycle;

            ActivationEvents.PreStart += ActivationEvents_PreStart;
            ActivationEvents.PostStart += ActivationEvents_PostStart;
            ActivationEvents.Shutdown += ActivationEvents_Shutdown;

            if (ActivationEvents.HasRunPreStart)
                lifecycle.BeforeStart();
            if (ActivationEvents.HasRunPostStart)
                lifecycle.AfterStart();
            if (ActivationEvents.HasRunShutdown)
                lifecycle.Shutdown();
        }

        void ActivationEvents_PreStart(object sender, EventArgs args)
        {
            lifecycle.BeforeStart();
        }

        void ActivationEvents_PostStart(object sender, EventArgs args)
        {
            lifecycle.AfterStart();
        }

        void ActivationEvents_Shutdown(object sender, EventArgs args)
        {
            lifecycle.Shutdown();
        }

        public void Configure()
        {
            Contract.Requires<WebException>(!IsConfigured, "Module already configured.");

            // begin
            this.configured = true;
            lifecycle.Init();
        }

        public bool IsConfigured
        {
            get { return configured; }
        }

        void IWebModule.Configure()
        {
            Configure();
        }

    }

}

