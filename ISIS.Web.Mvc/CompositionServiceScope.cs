using System.ComponentModel.Composition.Hosting;

namespace ISIS.Web.Mvc
{

    class CompositionServiceScope : CompositionService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionServiceScope(CompositionContainer parent)
            : base(parent)
        {

        }

    }

}
