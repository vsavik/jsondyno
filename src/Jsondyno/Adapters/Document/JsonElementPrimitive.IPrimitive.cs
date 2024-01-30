namespace Jsondyno.Adapters.Document;

partial class JsonElementPrimitive : IPrimitive
{
    // TODO: null check
    public string AsString() => Element.GetString()!;
}