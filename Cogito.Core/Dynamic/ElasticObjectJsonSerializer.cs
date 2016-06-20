using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;

using Cogito.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cogito.Dynamic
{

    /// <summary>
    /// Serializes <see cref="ElasticObject"/> instances to JSON.
    /// </summary>
    class ElasticDynamicObjectJsonConverter :
        JsonConverter
    {

        static readonly Regex timeSpanRegex = new Regex(@"^\d\d:\d\d:\d\d(\.\d+)?$", RegexOptions.Compiled);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElasticObject);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var o = value as ElasticObject;

            writer.WriteStartObject();

            if (o != null)
            {
                foreach (var i in o.GetDynamicMemberNames())
                {
                    writer.WritePropertyName(i);
                    serializer.Serialize(writer, o[i]);
                }
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JToken.ReadFrom(reader) as JObject;
            if (obj == null)
                return null;

            var o = (ElasticObject)Activator.CreateInstance(objectType);

            // apply each property
            foreach (var i in obj.Properties())
                o[i.Name] = ReadJson(i.Value, objectType, serializer);

            return o;
        }

        /// <summary>
        /// Reads a JToken as the appropriate type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectType"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        object ReadJson(JToken value, Type objectType, JsonSerializer serializer)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(serializer != null);

            // recommended type of value
            var t = JTokenToType(value, objectType, serializer);
            if (t == null)
                return null;

            // specified type is array, convert each element individually
            if (t.IsArray)
            {
                // generate new typed array with proper count
                var s = (Array)Activator.CreateInstance(t, new object[] { ((JArray)value).Count });

                // copy each deserialized item into new array
                int j = 0;
                foreach (var i in ((JArray)value))
                    s.SetValue(ReadJson(i, objectType, serializer), j++);

                return s;
            }

            // by default convert to specified type
            return value.ToObject(t, serializer);
        }

        /// <summary>
        /// Returns the optimal .NET type for the given <see cref="JToken"/>.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="objectType"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        Type JTokenToType(JToken token, Type objectType, JsonSerializer serializer)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Boolean:
                    return typeof(bool);
                case JTokenType.Date:
                    return typeof(DateTime);
                case JTokenType.Float:
                    return typeof(float);
                case JTokenType.Integer:
                    return typeof(int);
                case JTokenType.String:
                    if (timeSpanRegex.IsMatch(token.Value<string>()))
                        return typeof(TimeSpan);
                    else
                        return typeof(string);
                case JTokenType.TimeSpan:
                    return typeof(TimeSpan);
                case JTokenType.Array:
                    // find types of each element
                    var a = ((JArray)token).Select(i => JTokenToType(i, objectType, serializer)).ToArray();

                    // if all objects are the ElasticObject type, return an ElasticObject array
                    if (a.All(i => i == objectType))
                        return objectType.MakeArrayType();

                    // array of most common ancestor type
                    return TypeUtil.GetMostCompatibleTypes(a).First().MakeArrayType();
                case JTokenType.Object:
                    return objectType;
            }

            throw new InvalidOperationException();
        }

    }

}
