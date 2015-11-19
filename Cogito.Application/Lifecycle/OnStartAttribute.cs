﻿using System;
using System.ComponentModel.Composition;

namespace Cogito.Application.Lifecycle
{

    [AttributeUsage(AttributeTargets.Class)]
    public class OnStartAttribute : ExportAttribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OnStartAttribute(Type type)
            : base(typeof(IOnStart<>).MakeGenericType(type))
        {

        }

    }

}
