using System.Diagnostics;
using Jsondyno.Dynamic;
using Jsondyno.Internal;

namespace Jsondyno;

/// <summary>
/// <c>JsonConverter</c> implementation that converts JSON to <c>System.Dynamic</c> object.
/// </summary>
public sealed class DynamicObjectJsonConverter : JsonConverter<dynamic>
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (typeToConvert == typeof(object) ||
            typeToConvert == typeof(ArrayAdapter) ||
            typeToConvert == typeof(ObjectAdapter) ||
            typeToConvert == typeof(PrimitiveAdapter))
        {
            return true;
        }

        return false;
    }

    public override dynamic Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
        {
            return CreateFromJsonElement(ref reader, options);
        }

        Debug.Assert(options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonNode);

        return CreateFromJsonNode(ref reader, options);
    }

    private dynamic CreateFromJsonElement(
        ref Utf8JsonReader reader,
        JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement.Clone();

        return JsonElementValue.Create(element, options).ToDynamic();
    }

    private dynamic CreateFromJsonNode(
        ref Utf8JsonReader reader,
        JsonSerializerOptions options)
    {
        JsonNode rootNode = JsonNode.Parse(ref reader, options.ToNodeOpts())!;

        return JsonNodeValue<JsonNode>.Convert(rootNode, options).ToDynamic();
    }

    public override void Write(
        Utf8JsonWriter writer,
        dynamic value,
        JsonSerializerOptions options)
    {
        Type type = ((object)value).GetType();
        if (type == typeof(object) ||
            type == typeof(ArrayAdapter) ||
            type == typeof(ObjectAdapter) ||
            type == typeof(PrimitiveAdapter))
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}