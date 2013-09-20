using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Cogito.Web.Mvc
{

    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ControllerAttribute()
            : base(typeof(IController))
        {

        }

    }

}
