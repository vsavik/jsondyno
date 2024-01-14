namespace Dynamic.SystemTextJson.Document;

partial class DocumentProxy
{

    public static implicit operator JsonElement(DocumentProxy proxy) => proxy.Element;
}