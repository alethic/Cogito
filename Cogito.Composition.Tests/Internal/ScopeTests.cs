using System.ComponentModel.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Composition.Tests.Internal
{

    [TestClass]
    public class ScopeTests
    {

        public interface IChildScope : IScope
        {



        }

        [Export]
        public class InRootScope
        {

            InChildScope child;

            [ImportingConstructor]
            public InRootScope(
                InChildScope child)
            {
                this.child = child;
            }

        }

        [Export]
        [PartScope(typeof(IChildScope))]
        public class InChildScope
        {

            [ImportingConstructor]
            public InChildScope()
            {

            }

        }

        [TestMethod]
        public void Test_scope_filter_not_found()
        {
            var container = new CompositionContainer(new TypeCatalog(new[] { typeof(InRootScope), typeof(InChildScope) }));
            try
            {
                var item = container.GetExportedValue<InRootScope>();
            }
            catch (CompositionException e)
            {
                return;
            }
            Assert.Fail();
        }

    }

}
