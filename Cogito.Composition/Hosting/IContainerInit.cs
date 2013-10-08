using Cogito.Composition.Scoping;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Indicates a component taht is instantiated and invoked by the container when it is first discovered.
    /// </summary>
    public interface IContainerInit
    {

        void OnInit();

    }

}
