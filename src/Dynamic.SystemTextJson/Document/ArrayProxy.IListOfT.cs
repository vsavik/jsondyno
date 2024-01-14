using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dynamic.SystemTextJson.Document;

partial class ArrayProxy : IList<object?>
{
    public bool IsReadOnly => true;

    int ICollection<object?>.Count => Length;

    object? IList<object?>.this[int index]
    {
        get => this[index];
        set => throw new NotSupportedException("JsonElement is read only.");
    }

    public void CopyTo(object?[] array, int arrayIndex) => _data.CopyTo(array, arrayIndex);

    public bool Contains(object? item) => _data.Contains(item);

    public int IndexOf(object? item) => _data.IndexOf(item);

    void ICollection<object?>.Add(object? item) => throw new NotSupportedException("JsonElement is read only.");

    void ICollection<object?>.Clear() => throw new NotSupportedException("JsonElement is read only.");

    bool ICollection<object?>.Remove(object? item) => throw new NotSupportedException("JsonElement is read only.");

    void IList<object?>.Insert(int index, object? item) => throw new NotSupportedException("JsonElement is read only.");

    void IList<object?>.RemoveAt(int index) => throw new NotSupportedException("JsonElement is read only.");
}