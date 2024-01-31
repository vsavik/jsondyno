using System.Diagnostics;
using Jsondyno.Adapters;

namespace Jsondyno;

public sealed class DynamicObjectJsonConverter : JsonConverter<dynamic>
{
    public override dynamic Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            JsonElement element = document.RootElement.Clone();

            return element.CreateAdapter(options)!;
        }

        Debug.Assert(options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonNode);

        var jsonNodeOptions = new JsonNodeOptions
        {
            PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive
        };

        JsonNode node = JsonNode.Parse(ref reader, jsonNodeOptions)!;

        throw new NotSupportedException("Currently only JsonElement is supported.");
    }

    public override void Write(Utf8JsonWriter writer, dynamic value, JsonSerializerOptions options)
    {
        Type inputType = value.GetType();
        if (inputType == typeof(object))
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        else
        {
            // TODO: check for wrapper
            JsonSerializer.Serialize(writer, value, inputType, options);
        }
    }
}