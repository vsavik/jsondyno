using Jsondyno.Adapters.Document;

namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal static class JsonResultExtensions
{
    public static JsonElement GetJsonElement(
        this IJsonResult result,
        JsonSerializerOptions? options = null)
    {
        JsonSerializerOptions opts = options ?? JsonSerializerOptions.Default;
        JsonDocumentOptions docOpts = opts.ToDocumentOpts();
        using JsonDocument document = JsonDocument.Parse(result.GetStream(), docOpts);

        return document.RootElement.Clone();
    }

    public static JsonElementPrimitive CreateJsonElementPrimitive(
        this IJsonResult result,
        JsonSerializerOptions? options = null)
    {
        JsonSerializerOptions opts = options ?? JsonSerializerOptions.Default;
        JsonElement element = result.GetJsonElement(opts);

        return new JsonElementPrimitive(element, opts);
    }

    public static JsonElementArray CreateJsonElementArray(
        this IJsonResult result,
        JsonSerializerOptions? options = null)
    {
        JsonSerializerOptions opts = options ?? JsonSerializerOptions.Default;
        JsonElement element = result.GetJsonElement(opts);

        return new JsonElementArray(element, opts);
    }
}