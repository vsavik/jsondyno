namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementArray : JsonElementValue<IArray>, IReadOnlyList<object?>
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

            // TODO: use factory to create item
            _data[i] = (object)arrayElement;
        }
    }

    protected override IArray Self => this;

    public int Length { get; }

    public int Count => Length;

    public object? this[int index] => _data[index];

    public IEnumerator<object?> GetEnumerator() => _data.AsEnumerable().GetEnumerator();
}