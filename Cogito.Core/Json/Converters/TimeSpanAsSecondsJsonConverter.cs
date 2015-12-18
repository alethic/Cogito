using System;

using Newtonsoft.Json;

namespace Cogito.Json.Converters
{

    /// <summary>
    /// Converts to and from a <see cref="TimeSpan"/> stored as a number of seconds.
    /// </summary>
    public class TimeSpanFromSecondsJsonConverter :
        JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
                writer.WriteValue(((TimeSpan)value).TotalSeconds);
            else
                writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ts = serializer.Deserialize<double?>(reader);
            if (ts != null)
                return TimeSpan.FromSeconds((double)ts);
            else
                return null;
        }

    }

}
