namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementPrimitive : JsonElementValue<IPrimitive>
{
    public JsonElementPrimitive(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
    }

    protected override IPrimitive Self => this;
}