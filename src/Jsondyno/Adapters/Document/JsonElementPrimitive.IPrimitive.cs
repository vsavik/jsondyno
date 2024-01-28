namespace Jsondyno.Adapters.Document;

partial class JsonElementPrimitive : IPrimitive
{
    public string? GetString() => Element.GetString();
}