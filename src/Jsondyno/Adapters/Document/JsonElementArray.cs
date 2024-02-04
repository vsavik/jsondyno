namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementArray : JsonElementValue<IArray>
{
    private readonly object?[] _data;

    private bool _isInitialized;

    public JsonElementArray(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
        Length = Element.GetArrayLength();
        _data = new object?[Length];
    }

    protected override IArray Self => this;

    private object?[] Data
    {
        get
        {
            EnsureInitialized();

            return _data;
        }
    }

    private void EnsureInitialized()
    {
        if (_isInitialized)
        {
            return;
        }

        using JsonElement.ArrayEnumerator enumerator = Element.EnumerateArray();
        for (int i = 0; i < _data.Length && enumerator.MoveNext(); i++)
        {
            JsonElement arrayElement = enumerator.Current;
            _data[i] = arrayElement.CreateAdapter(Options);
        }

        _isInitialized = true;
    }
}