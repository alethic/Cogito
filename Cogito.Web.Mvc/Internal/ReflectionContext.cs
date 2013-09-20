using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Context;

namespace Cogito.Web.Mvc.Internal
{

    public class ReflectionContext : CustomReflectionContext
    {

        protected override IEnumerable<PropertyInfo> AddProperties(Type type)
        {
            //if (Attribute.IsDefined(type, typeof(ControllerAttribute), false))
            //    yield return new ControllerMetadataAttribute(type);

            foreach (var t in base.AddProperties(type))
                yield return t;
        }

    }

}
