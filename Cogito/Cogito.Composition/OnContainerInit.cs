using System;
using System.ComponentModel.Composition;

using Cogito.Composition.Hosting;

namespace Cogito.Composition
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnContainerInit : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnContainerInit()
            :base(typeof(IContainerInit))
        {

        }

    }

}
