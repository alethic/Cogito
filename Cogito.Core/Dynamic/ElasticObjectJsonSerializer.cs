using System;
using System.Diagnostics.Contracts;
using System.Linq;
using Cogito.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cogito.Dynamic
{

    public class ElasticDynamicObjectJsonConverter :
        JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElasticObject);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var o = value as ElasticObject;
            if (o == null)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
                return;
            }

            writer.WriteStartObject();

            foreach (var i in o.GetDynamicMemberNames())
            {
                writer.WritePropertyName(i);
                serializer.Serialize(writer, o[i]);
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

        object ReadJson(JToken value, Type objectType, JsonSerializer serializer)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(serializer != null);

            return value.ToObject(JTokenToType(value, objectType, serializer), serializer);
        }

        Type JTokenToType(JToken token, Type objectType, JsonSerializer serializer)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return typeof(object);
                case JTokenType.Boolean:
                    return typeof(bool);
                case JTokenType.Date:
                    return typeof(DateTime?);
                case JTokenType.Float:
                    return typeof(float?);
                case JTokenType.Integer:
                    return typeof(int?);
                case JTokenType.String:
                    return typeof(string);
                case JTokenType.TimeSpan:
                    return typeof(TimeSpan?);
                case JTokenType.Array:
                    var a = ((JArray)token).Select(i => JTokenToType(i, objectType, serializer)).ToArray();
                    if (a.All(i => i == objectType))
                        return objectType.MakeArrayType();
                    else
                    {
                        var t = TypeUtil.GetMostCompatibleTypes(a).First();
                        return t.MakeArrayType();
                    }
                case JTokenType.Object:
                    return objectType;
            }

            throw new InvalidOperationException();
        }

    }

}
