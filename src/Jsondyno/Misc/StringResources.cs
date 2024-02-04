namespace Jsondyno.Misc;

internal static class StringResources
{
    public const string NullStringData = "Fatal: JsonElement.GetString returned null.";

    public const string JsonElementAdapterIsReadOnly = "Adapters based on JsonElement are read only. Use JsonNode instead";

    public static string CannotCreateDynamicAdapter(JsonValueKind valueKind) =>
        $"Can't create dynamic adapter for JsonElement with kind {valueKind}.";
}