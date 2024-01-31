using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementObject : IDictionary
{
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    int ICollection.Count => throw new NotImplementedException();

    bool ICollection.IsSynchronized => throw new NotImplementedException();

    object ICollection.SyncRoot => throw new NotImplementedException();

    ICollection IDictionary.Keys => throw new NotImplementedException();

    ICollection IDictionary.Values => throw new NotImplementedException();

    bool IDictionary.IsFixedSize => throw new NotImplementedException();

    bool IDictionary.IsReadOnly => throw new NotImplementedException();

    object? IDictionary.this[object key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    IDictionaryEnumerator IDictionary.GetEnumerator() => throw new NotImplementedException();

    void ICollection.CopyTo(Array array, int index) => throw new NotImplementedException();

    void IDictionary.Add(object key, object? value) => throw new NotImplementedException();

    bool IDictionary.Contains(object key) => throw new NotImplementedException();

    void IDictionary.Remove(object key) => throw new NotImplementedException();

    void IDictionary.Clear() => throw new NotImplementedException();
}