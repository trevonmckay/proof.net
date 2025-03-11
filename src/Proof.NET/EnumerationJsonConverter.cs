using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Proof.NET
{
    internal class EnumerationJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
            return Array.Exists(underlyingType.GetInterfaces(), i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumeration<>));
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
            Type? enumerationInterfaceType = Array.Find(underlyingType.GetInterfaces(), i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumeration<>));
            if (enumerationInterfaceType is null)
            {
                throw new JsonException($"The type {typeToConvert} cannot be handled by this converter.");
            }

            Type valueType = enumerationInterfaceType.GetGenericArguments()[0];
            Type converterType = typeof(EnumerationJsonConverterImpl<,>).MakeGenericType(underlyingType, valueType);
            return (JsonConverter?)Activator.CreateInstance(converterType);
        }

        private sealed class EnumerationJsonConverterImpl<TEnum, TValue> : JsonConverter<TEnum>
            where TEnum : IEnumeration<TValue>
        {
            public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                TValue value = JsonSerializer.Deserialize<TValue>(ref reader, options) ?? throw new JsonException($"Unable to convert '{reader.GetString()}' to {typeof(TEnum)}");
                return (TEnum?)Activator.CreateInstance(typeToConvert, value);
            }

            public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value.Value, options);
            }
        }
    }
}
