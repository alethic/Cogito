using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Cogito.Reflection
{

    /// <summary>
    /// Provides methods to invoke other methods based on generic type signatures derived through reflection.
    /// </summary>
    public static class GenericInvoker
    {

        /// <summary>
        /// Invokes the method given by <paramref name="func"/>, replacing it's generic type argument with that
        /// specified.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static object Invoke(Type t1, Expression<Func<object>> func)
        {
            Contract.Requires<NotImplementedException>(false);

            ////// verify arguments
            //Contract.Requires<ArgumentNullException>(t1 != null);
            //Contract.Requires<ArgumentNullException>(func != null);

            ////// verify expression
            //Contract.Requires<ArgumentException>(func.Body != null);
            //Contract.Requires<ArgumentException>(func.Body.NodeType == ExpressionType.Call);
            //Contract.Requires<ArgumentException>(func.Body is MethodCallExpression);

            //var b = (MethodCallExpression)func.Body;
            //var m = b.Method;
            //var g = m.GetGenericMethodDefinition();

            //// generate new concrete method
            //var a = new Type[g.GetGenericArguments().Length];
            //a[0] = t1;
            //var n = g.MakeGenericMethod(a);

            //var v = new object[n.GetParameters().Length];
            //for (int i = 0; i < v.Length; i ++)
            //    v[i] = b.Arguments[i].
            return null;
        }

    }

}
