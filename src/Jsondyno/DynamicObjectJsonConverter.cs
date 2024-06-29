using System.Diagnostics;
using Jsondyno.Internal;
using Jsondyno.Internal.Dynamic;
using Jsondyno.Internal.Serialization;

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
        var context = new Context(options);
        if (options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
        {
            return CreateFromJsonElement(ref reader, context);
        }

        Debug.Assert(options.UnknownTypeHandling == JsonUnknownTypeHandling.JsonNode);

        return CreateFromJsonNode(ref reader, context);
    }

    private dynamic CreateFromJsonElement(
        ref Utf8JsonReader reader,
        Context context)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement.Clone();

        return new JsonElementValue(element).ToDynamic(context);
    }

    private dynamic CreateFromJsonNode(
        ref Utf8JsonReader reader,
        Context context)
    {
        JsonNode rootNode = JsonNode.Parse(ref reader, context.Options.ToNodeOpts())!;

        return JsonNodeValue<JsonNode>.Convert(rootNode)!.ToDynamic(context);
    }

    public override void Write(
        Utf8JsonWriter writer,
        dynamic value,
        JsonSerializerOptions options)
    {
        if (value.GetType() == typeof(object))
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        //throw new NotSupportedException("Currently not suported.");
    }
}