using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

using Cogito.Collections;

using Newtonsoft.Json;

namespace Cogito.Dynamic
{

    /// <summary>
    /// Provides a dynamic object that can be serialized by multiple serialization providers.
    /// </summary>
    [Serializable]
    [KnownType("GetKnownTypes")]
    [JsonConverter(typeof(ElasticDynamicObjectJsonConverter))]
    public class ElasticObject :
        IDynamicMetaObjectProvider,
        ISerializable
    {

        /// <summary>
        /// Primative types for which known types will be returned.
        /// </summary>
        static readonly Type[] knownTypesBase = new[]
        {
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(UInt16),
            typeof(UInt32),
            typeof(UInt64),
            typeof(Single),
            typeof(Double),
            typeof(string),
        };

        /// <summary>
        /// Final set of known types.
        /// </summary>
        static readonly Type[] knownTypes = GetKnownTypesEnum().ToArray();

        /// <summary>
        /// Returns known types.
        /// </summary>
        /// <returns></returns>
        static Type[] GetKnownTypes()
        {
            return knownTypes;
        }

        /// <summary>
        /// Iterates all the known types.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<Type> GetKnownTypesEnum()
        {
            foreach (var t in knownTypesBase)
            {
                yield return t;
                yield return t.MakeArrayType();

                if (t.IsValueType)
                    yield return typeof(Nullable<>).MakeGenericType(t);
            }
        }

        readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ElasticObject()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ElasticObject(SerializationInfo info, StreamingContext context)
        {
            Contract.Requires<ArgumentNullException>(info != null);

            foreach (var i in info)
                dictionary[i.Name] = i.Value;
        }

        /// <summary>
        /// Gets the value with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [IgnoreDataMember]
        public dynamic this[string name]
        {
            get { Contract.Requires<ArgumentNullException>(name != null); return dictionary.GetOrDefault(name); }
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
            return new ElasticObjectMetaObject(expression, BindingRestrictions.GetInstanceRestriction(expression, this), this);
        }

        /// <summary>
        /// Used by the <see cref="ElasticObjectMetaObject"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal object SetValue(string name, object value)
        {
            return dictionary[name] = value;
        }

        /// <summary>
        /// Used by the <see cref="ElasticObjectMetaObject"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal object GetValue(string name)
        {
            return dictionary.GetOrDefault(name);
        }

        /// <summary>
        /// Gets the serializable data.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var kvp in dictionary)
                info.AddValue(kvp.Key, kvp.Value);
        }

    }

}
