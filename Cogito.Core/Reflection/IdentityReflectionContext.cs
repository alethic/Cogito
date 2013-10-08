using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Context;

namespace Cogito.Reflection
{

    public class IdentityReflectionContext : CustomReflectionContext
    {

        protected override IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
        {
            var l = member.GetCustomAttributes().ToList();
            return l;
        }

        protected override IEnumerable<object> GetCustomAttributes(ParameterInfo parameter, IEnumerable<object> declaredAttributes)
        {
            var l = parameter.GetCustomAttributes().ToList();
            return l;
        }

        public override TypeInfo MapType(TypeInfo type)
        {
            var t = base.MapType(type);
            return t;
        }

        public override Assembly MapAssembly(Assembly assembly)
        {
            var a = base.MapAssembly(assembly);
            return a;
        }

    }

}
