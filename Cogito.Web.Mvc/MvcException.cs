using Cogito.Application;

namespace Cogito.Web.Mvc
{

    public class MvcException : ModuleException<IMvcModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public MvcException(IMvcModule module)
            : base(module)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public MvcException(IMvcModule module, string message)
            : base(module)
        {

        }

    }


}
