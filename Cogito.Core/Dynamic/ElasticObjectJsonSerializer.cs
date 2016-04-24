using System;
using System.Diagnostics.Contracts;

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

            var o = new ElasticObject();

            foreach (var i in obj.Properties())
                o[i.Name] = ReadJson((JToken)i.Value, serializer);

            return o;
        }

        object ReadJson(JToken value, JsonSerializer serializer)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(serializer != null);

            switch (value.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Boolean:
                    return value.Value<bool>();
                case JTokenType.Date:
                    return value.Value<DateTime?>();
                case JTokenType.Float:
                    return value.Value<float?>();
                case JTokenType.Integer:
                    return value.Value<int?>();
                case JTokenType.String:
                    return value.Value<string>();
                case JTokenType.TimeSpan:
                    return value.Value<TimeSpan?>();
                case JTokenType.Object:
                    return serializer.Deserialize<ElasticObject>(value.CreateReader());
            }

            throw new NotSupportedException();
        }

    }

}
