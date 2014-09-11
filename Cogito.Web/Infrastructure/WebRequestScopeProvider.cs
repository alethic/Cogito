using System;
using System.ComponentModel.Composition;
using System.Web;

using Cogito.Collections;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Infrastructure
{

    [Export(typeof(IScopeProvider))]
    public class WebRequestScopeProvider :
        IScopeProvider
    {

        internal static readonly string CONTEXT_KEY = "Cogito.Web.Scope";

        public CompositionContainer Resolve(Type scopeType)
        {
            // supports IWebRequestScope
            if (!typeof(IWebRequestScope).IsAssignableFrom(scopeType))
                return null;

            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                var r = ctx.Items.GetOrDefault(CONTEXT_KEY) as Ref<CompositionContainer>;
                if (r != null)
                    return r.Value;
            }

            return null;
        }

        public void Register(Type scopeType, CompositionContainer container)
        {
            // supports IWebRequestScope
            if (!typeof(IWebRequestScope).IsAssignableFrom(scopeType))
                return;

            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                // find existing item
                var r = ctx.Items.GetOrDefault(CONTEXT_KEY) as Ref<CompositionContainer>;
                if (r != null)
                {
                    // remove existing reference
                    if (r.Value != container)
                    {
                        ctx.Items.Remove(CONTEXT_KEY);
                        r.Dispose();
                    }
                }

                // store reference
                ctx.Items[CONTEXT_KEY] = container.GetExportedValue<IContainerProvider>().GetContainerRef();
            }
        }

    }

}
