using System.Diagnostics;
using Dynamic.SystemTextJson.Document;

namespace Dynamic.SystemTextJson;

public sealed class DynamicProxyJsonConverter : JsonConverter<dynamic>
{
    public override bool CanConvert(Type typeToConvert)
    {
        // TODO: check wrappers for serialization
        Console.WriteLine($"#CanConvert {typeToConvert}");
        return typeToConvert == typeof(object);
    }

    public override dynamic Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        Console.WriteLine($"#Read {typeToConvert}");
        if (options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            JsonElement element = document.RootElement.Clone();

            return element.CreateProxy(options)!;
        }

        Debug.Assert(options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonNode);

        var jsonNodeOptions = new JsonNodeOptions
        {
            PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive
        };

        JsonNode node = JsonNode.Parse(ref reader, jsonNodeOptions)!;

        throw new NotSupportedException("Currently only JsonElement is supported.");

        //return node;
    }

    public override void Write(
        Utf8JsonWriter writer,
        dynamic value,
        JsonSerializerOptions options)
    {
        Type inputType = value.GetType();
        if (inputType == typeof(object))
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        else
        {
            Console.WriteLine($"#Write {value.GetType()}");
            // TODO: check for wrapper
            JsonSerializer.Serialize(writer, value, inputType, options);
        }
    }
}