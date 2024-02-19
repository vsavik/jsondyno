namespace Jsondyno.Misc;

internal static class StringResources
{
    public static string UnknownValueKind(JsonValueKind valueKind) =>
        $"Cannot create dynamic adapter for element kind is {valueKind}.";
}