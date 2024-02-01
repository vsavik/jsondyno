namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementArray : JsonElementValue<IArray>
{
    private readonly object?[] _data;

    public JsonElementArray(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
        Length = Element.GetArrayLength();
        _data = new object?[Length];

        using JsonElement.ArrayEnumerator enumerator = Element.EnumerateArray();
        for (int i = 0; i < _data.Length && enumerator.MoveNext(); i++)
        {
            JsonElement arrayElement = enumerator.Current;
            _data[i] = arrayElement.CreateAdapter(Options);
        }
    }

    protected override IArray Self => this;
}