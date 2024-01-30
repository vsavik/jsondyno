namespace Jsondyno.Misc;

internal static class StringResources
{
    public static string CannotCreateDynamicAdapter(JsonValueKind valueKind) =>
        $"Can't create dynamic adapter for JsonElement with kind {valueKind}.";        
}