namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IList<object?>
{
    int ICollection<object?>.Count => throw new NotImplementedException();
    
    bool ICollection<object?>.IsReadOnly => throw new NotImplementedException();

    void ICollection<object?>.Add(object? item) => throw new NotImplementedException();

    void ICollection<object?>.Clear() => throw new NotImplementedException();

    bool ICollection<object?>.Contains(object? item) => throw new NotImplementedException();

    void ICollection<object?>.CopyTo(object?[] array, int arrayIndex) => throw new NotImplementedException();

    bool ICollection<object?>.Remove(object? item) => throw new NotImplementedException();
    
    object? IList<object?>.this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    int IList<object?>.IndexOf(object? item) => throw new NotImplementedException();

    void IList<object?>.Insert(int index, object? item) => throw new NotImplementedException();

    void IList<object?>.RemoveAt(int index) => throw new NotImplementedException();
}