using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Cogito.Dynamic
{

    /// <summary>
    /// Handles dynamic dispatch for a <see cref="ElasticObject"/>.
    /// </summary>
    class ElasticObjectMetaObject :
         DynamicMetaObject
    {

        static readonly MethodInfo getValueMethod = typeof(ElasticObject).GetTypeInfo().GetMethod(nameof(ElasticObject.GetValue), BindingFlags.NonPublic | BindingFlags.Instance);
        static readonly MethodInfo setValueMethod = typeof(ElasticObject).GetTypeInfo().GetMethod(nameof(ElasticObject.SetValue), BindingFlags.NonPublic | BindingFlags.Instance);
        static readonly Type type = typeof(ElasticObject);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="restrictions"></param>
        /// <param name="value"></param>
        public ElasticObjectMetaObject(Expression expression, BindingRestrictions restrictions, ElasticObject value)
            : base(expression, restrictions, value)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            if (restrictions == null)
                throw new ArgumentNullException(nameof(restrictions));
        }

        /// <summary>
        /// The runtime value represented by this <see cref="ElasticObjectMetaObject"/>.
        /// </summary>
        new ElasticObject Value
        {
            get { return (ElasticObject)base.Value; }
        }

        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            var target = Expression.Call(
                Expression.Convert(Expression, type),
                getValueMethod,
                Expression.Constant(binder.Name));

            return new DynamicMetaObject(target, Restrictions);
        }

        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            var target = Expression.Call(
                Expression.Convert(Expression, type),
                setValueMethod,
                Expression.Constant(binder.Name),
                Expression.Convert(value.Expression, typeof(object)));

            return new DynamicMetaObject(target, Restrictions);
        }

        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            return base.BindConvert(binder);
        }

        public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
        {
            return base.BindUnaryOperation(binder);
        }

        public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
        {
            return base.BindBinaryOperation(binder, arg);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return Value.GetDynamicMemberNames();
        }

    }

}
