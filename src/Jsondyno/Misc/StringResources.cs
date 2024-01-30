namespace Jsondyno.Misc;

internal static class StringResources
{
    public const string NullStringData = "Fatal: JsonElement.GetString returned null.";

    public static string CannotCreateDynamicAdapter(JsonValueKind valueKind) =>
        $"Can't create dynamic adapter for JsonElement with kind {valueKind}.";
}