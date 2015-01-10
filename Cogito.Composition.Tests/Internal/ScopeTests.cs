using System.ComponentModel.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Composition.Tests.Internal
{

    [TestClass]
    public class ScopeTests
    {

        public interface IChildScope
        {

        }

        [Export]
        public class InRootScope
        {



        }

        [Export]
        public class InRootScopeWithChild
        {

            InChildScope child;

            [ImportingConstructor]
            public InRootScopeWithChild(
                InChildScope child)
            {
                this.child = child;
            }

        }

        [Export]
        [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IChildScope))]
        public class InChildScope
        {

            [ImportingConstructor]
            public InChildScope()
            {

            }

        }

        [Export]
        [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IChildScope))]
        public class InChildScopeWithRoot
        {

            [ImportingConstructor]
            public InChildScopeWithRoot(InRootScope root)
            {

            }

        }

        [TestMethod]
        public void Test_root_without_child_found()
        {
            Assert.IsNotNull(ContainerManager.GetDefaultTypeResolver().Resolve<InRootScope>());
        }

        [TestMethod]
        public void Test_root_with_scope_child_not_found()
        {
            Assert.IsNull(ContainerManager.GetDefaultTypeResolver().Resolve<InRootScopeWithChild>());
        }

        [TestMethod]
        public void Test_child_scope_found()
        {
            Assert.IsNotNull(ContainerManager.GetDefaultTypeResolver().Resolve<IScopeTypeResolver>().Resolve<InChildScope, IChildScope>());
        }

        [TestMethod]
        public void Test_root_scope_found_from_child()
        {
            Assert.IsNotNull(ContainerManager.GetDefaultTypeResolver().Resolve<IScopeTypeResolver>().Resolve<InChildScopeWithRoot, IChildScope>());
        }

    }

}
