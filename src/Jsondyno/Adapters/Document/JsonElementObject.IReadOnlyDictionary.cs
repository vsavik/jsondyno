using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementObject : IReadOnlyDictionary<string, object?>
{
    IEnumerator<KeyValuePair<string, object?>> IEnumerable<KeyValuePair<string, object?>>.GetEnumerator() =>
        throw new NotImplementedException();

    int IReadOnlyCollection<KeyValuePair<string, object?>>.Count => throw new NotImplementedException();

    IEnumerable<string> IReadOnlyDictionary<string, object?>.Keys => throw new NotImplementedException();

    IEnumerable<object?> IReadOnlyDictionary<string, object?>.Values => throw new NotImplementedException();

    object? IReadOnlyDictionary<string, object?>.this[string key] => throw new NotImplementedException();

    bool IReadOnlyDictionary<string, object?>.ContainsKey(string key) => throw new NotImplementedException();

    bool IReadOnlyDictionary<string, object?>.TryGetValue(string key, out object? value) =>
        throw new NotImplementedException();
}