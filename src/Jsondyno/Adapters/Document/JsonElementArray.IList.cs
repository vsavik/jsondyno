using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IList
{
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    int ICollection.Count => throw new NotImplementedException();

    bool ICollection.IsSynchronized => throw new NotImplementedException();

    object ICollection.SyncRoot => throw new NotImplementedException();

    void ICollection.CopyTo(Array array, int index) => throw new NotImplementedException();

    bool IList.IsFixedSize => throw new NotImplementedException();

    bool IList.IsReadOnly => throw new NotImplementedException();
    
    object? IList.this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    int IList.Add(object? value) => throw new NotImplementedException();

    void IList.Clear() => throw new NotImplementedException();

    bool IList.Contains(object? value) => throw new NotImplementedException();

    int IList.IndexOf(object? value) => throw new NotImplementedException();

    void IList.Insert(int index, object? value) => throw new NotImplementedException();

    void IList.Remove(object? value) => throw new NotImplementedException();

    void IList.RemoveAt(int index) => throw new NotImplementedException();
}