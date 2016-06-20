using System;

using Newtonsoft.Json;

namespace Cogito.Media
{

    /// <summary>
    /// Provides JSON serialization for a <see cref="MediaRange"/>.
    /// </summary>
    class MediaRangeJsonConverter :
         JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(MediaRange) == objectType;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((MediaRange)value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (MediaRange)reader.ReadAsString();
        }

    }

}
