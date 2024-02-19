namespace Jsondyno.Misc;

internal static class JsonSerializerOptionsExtensions
{
    public static JsonDocumentOptions ToDocumentOpts(this JsonSerializerOptions options) =>
        new()
        {
            AllowTrailingCommas = options.AllowTrailingCommas,
            CommentHandling = options.ReadCommentHandling,
            MaxDepth = options.MaxDepth
        };

    public static JsonNodeOptions ToNodeOpts(this JsonSerializerOptions options) =>
        new() { PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive };
}