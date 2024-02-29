namespace Jsondyno.Misc;

internal static class StringResources
{
    public static string UnknownValueKind(JsonValueKind valueKind) =>
        $"Cannot create dynamic adapter: json {valueKind} is not supported.";
}