namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IList<object?>
{
    IEnumerator<object?> IEnumerable<object?>.GetEnumerator() =>
        Data.AsEnumerable().GetEnumerator();

    int ICollection<object?>.Count => Length;

    bool ICollection<object?>.IsReadOnly => true;

    void ICollection<object?>.Add(object? item) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    void ICollection<object?>.Clear() =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    bool ICollection<object?>.Contains(object? item) =>
        Array.IndexOf(Data, item) >= 0;

    void ICollection<object?>.CopyTo(object?[] array, int arrayIndex) =>
        Data.CopyTo(array, arrayIndex);

    bool ICollection<object?>.Remove(object? item) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    object? IList<object?>.this[int index]
    {
        get => Data[index];
        set => throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);
    }

    int IList<object?>.IndexOf(object? item) =>
        Array.IndexOf(Data, item);

    void IList<object?>.Insert(int index, object? item) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);

    void IList<object?>.RemoveAt(int index) =>
        throw new NotSupportedException(SR.JsonElementAdapterIsReadOnly);
}