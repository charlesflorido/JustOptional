using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JustOptional
{
    public class OptionalJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type valueType = typeToConvert.GetGenericArguments()[0];
            Type converterType = typeof(OptionalJsonConverter<>).MakeGenericType(valueType);
            return (JsonConverter)Activator.CreateInstance(converterType);
        }
    }
}
