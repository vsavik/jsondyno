using System.Collections;

namespace Jsondyno.Adapters.Document;

internal sealed partial class JsonElementObject : JsonElementValue<IObject>, IReadOnlyDictionary<string, object?>
{
    public JsonElementObject(in JsonElement element, JsonSerializerOptions options)
        : base(in element, options)
    {
    }

    protected override IObject Self => this;
    
    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count { get; }
    public bool ContainsKey(string key) => throw new NotImplementedException();

    public bool TryGetValue(string key, out object? value) => throw new NotImplementedException();

    public object? this[string key] => throw new NotImplementedException();

    public IEnumerable<string> Keys { get; }
    public IEnumerable<object?> Values { get; }
}