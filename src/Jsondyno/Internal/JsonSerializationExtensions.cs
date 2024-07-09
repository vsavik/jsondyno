namespace Jsondyno.Internal;

internal static class JsonSerializationExtensions
{
    private static readonly JsonSerializerOptions s_options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        WriteIndented = true
    };

    public static string ToIntendedJsonString(in this JsonElement element) =>
        JsonSerializer.Serialize(element, s_options);

    public static string ToIntendedJsonString(this JsonNode node) =>
        node.ToJsonString(s_options);
}