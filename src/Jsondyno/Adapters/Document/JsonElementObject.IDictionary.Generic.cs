using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementObject : IDictionary<string, object?>
{
    int ICollection<KeyValuePair<string, object?>>.Count => throw new NotImplementedException();

    bool ICollection<KeyValuePair<string, object?>>.IsReadOnly => throw new NotImplementedException();

    void ICollection<KeyValuePair<string, object?>>.Add(KeyValuePair<string, object?> item) =>
        throw new NotImplementedException();

    void ICollection<KeyValuePair<string, object?>>.Clear() => throw new NotImplementedException();

    bool ICollection<KeyValuePair<string, object?>>.Contains(KeyValuePair<string, object?> item) =>
        throw new NotImplementedException();

    void ICollection<KeyValuePair<string, object?>>.CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex) =>
        throw new NotImplementedException();

    bool ICollection<KeyValuePair<string, object?>>.Remove(KeyValuePair<string, object?> item) =>
        throw new NotImplementedException();

    object? IDictionary<string, object?>.this[string key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    ICollection<string> IDictionary<string, object?>.Keys => throw new NotImplementedException();

    ICollection<object?> IDictionary<string, object?>.Values => throw new NotImplementedException();

    void IDictionary<string, object?>.Add(string key, object? value) => throw new NotImplementedException();

    bool IDictionary<string, object?>.ContainsKey(string key) => throw new NotImplementedException();

    bool IDictionary<string, object?>.TryGetValue(string key, out object? value) => throw new NotImplementedException();

    bool IDictionary<string, object?>.Remove(string key) => throw new NotImplementedException();
}