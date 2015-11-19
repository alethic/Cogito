﻿using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnAfterStartAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnAfterStartAttribute(Type type)
            : base(typeof(IOnAfterStart<>).MakeGenericType(type))
        {

        }

    }

}
