namespace Dynamic.SystemTextJson.Document;

internal sealed class ObjectProxy : DocumentProxy
{
    public ObjectProxy(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
    }
}