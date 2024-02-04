using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IList
{
    IEnumerator IEnumerable.GetEnumerator() =>
        Data.GetEnumerator();

    int ICollection.Count => Length;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    void ICollection.CopyTo(Array array, int index) =>
        Data.CopyTo(array, index);

    bool IList.IsFixedSize => true;

    bool IList.IsReadOnly => true;

    object? IList.this[int index]
    {
        get => Data[index];
        set => throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);
    }

    int IList.Add(object? value) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    void IList.Clear() =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    bool IList.Contains(object? value) =>
        Array.IndexOf(Data, value) >= 0;

    int IList.IndexOf(object? value) =>
        Array.IndexOf(Data, value);

    void IList.Insert(int index, object? value) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    void IList.Remove(object? value) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    void IList.RemoveAt(int index) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);
}