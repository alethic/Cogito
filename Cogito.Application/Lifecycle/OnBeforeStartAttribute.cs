﻿using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnBeforeStartAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnBeforeStartAttribute(Type type)
            : base(typeof(IOnBeforeStart<>).MakeGenericType(type))
        {

        }

    }

}
