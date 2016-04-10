using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Cogito.Collections;

namespace Cogito.Dynamic
{

    /// <summary>
    /// Provides a dynamic object that can be serialized by multiple serialization providers.
    /// </summary>
    [DataContract]
    [KnownType(typeof(SerializableDynamicObject))]
    [KnownType(typeof(SerializableDynamicObject[]))]
    [JsonConverter(typeof(SerializableDynamicObjectJsonConverter))]
    public class SerializableDynamicObject :
        IDynamicMetaObjectProvider
    {

        [DataMember]
        readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        /// <summary>
        /// Gets the value with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [IgnoreDataMember]
        public dynamic this[string name]
        {
            get { return dictionary.GetOrDefault(name); }
            set { Contract.Requires<ArgumentNullException>(name != null); dictionary[name] = value; }
        }

        /// <summary>
        /// Gets the set of dynamic member names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDynamicMemberNames()
        {
            return dictionary.Keys;
        }

        /// <summary>
        /// Gets a metaobject to be used by the dynamic framework.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public DynamicMetaObject GetMetaObject(Expression expression)
        {
            return new SerializableDynamicObjectMetaObject(expression, BindingRestrictions.GetInstanceRestriction(expression, this), this);
        }

        /// <summary>
        /// Used by the <see cref="SerializableDynamicObjectMetaObject"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal object SetValue(string name, object value)
        {
            return this[name] = value;
        }

        /// <summary>
        /// Used by the <see cref="SerializableDynamicObjectMetaObject"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal object GetValue(string name)
        {
            return this[name];
        }

    }

}
