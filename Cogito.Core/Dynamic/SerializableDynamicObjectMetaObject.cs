using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Cogito.Dynamic
{

    public class SerializableDynamicObjectMetaObject :
         DynamicMetaObject
    {

        readonly Type type;
        readonly MethodInfo getValueMethod;
        readonly MethodInfo setValueMethod;
        readonly BindingRestrictions restrictions;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="restrictions"></param>
        /// <param name="value"></param>
        public SerializableDynamicObjectMetaObject(Expression expression, BindingRestrictions restrictions, object value)
            : base(expression, restrictions, value)
        {
            Contract.Requires<ArgumentNullException>(expression != null);
            Contract.Requires<ArgumentNullException>(restrictions != null);
            Contract.Requires<ArgumentException>(value is SerializableDynamicObject);

            this.type = value.GetType();
            this.getValueMethod = type.GetMethod(nameof(SerializableDynamicObject.GetValue), BindingFlags.NonPublic | BindingFlags.Instance);
            this.setValueMethod = type.GetMethod(nameof(SerializableDynamicObject.SetValue), BindingFlags.NonPublic | BindingFlags.Instance);
            this.restrictions = BindingRestrictions.GetTypeRestriction(Expression, type);
        }

        /// <summary>
        /// The runtime value represented by this <see cref="SerializableDynamicObjectMetaObject"/>.
        /// </summary>
        new SerializableDynamicObject Value
        {
            get { return (SerializableDynamicObject)base.Value; }
        }

        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            var target = Expression.Call(
                Expression.Convert(Expression, type),
                getValueMethod,
                Expression.Constant(binder.Name));

            return new DynamicMetaObject(target, restrictions);
        }

        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            var target = Expression.Call(
                Expression.Convert(Expression, type),
                setValueMethod,
                Expression.Constant(binder.Name),
                Expression.Convert(value.Expression, typeof(object)));

            return new DynamicMetaObject(target, restrictions);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return Value.GetDynamicMemberNames();
        }

    }

}
