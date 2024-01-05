using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace Dynamic.SystemTextJson;

internal sealed class DynamicProxyJsonConverter : JsonConverter<dynamic>
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

            return JsonElementDynamicWrapper.Create(element, options)!;

            // the code below is better but it works correctly only from .NET 8
            // because JsonElement.ParseValue contains root JsonDocument that should be disposed
            // var element = JsonElement.ParseValue(ref reader);
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