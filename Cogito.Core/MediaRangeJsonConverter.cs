using System;

using Newtonsoft.Json;

namespace Cogito
{

    /// <summary>
    /// Provides serialization for a <see cref="MediaRange"/>.
    /// </summary>
    public class MediaRangeJsonConverter :
         JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(MediaRange) == objectType;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((string)(MediaRange)value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (MediaRange)reader.ReadAsString();
        }

    }

}
