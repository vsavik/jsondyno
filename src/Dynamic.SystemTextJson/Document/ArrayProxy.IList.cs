using System.Collections;

namespace Dynamic.SystemTextJson.Document;

partial class ArrayProxy : IList
{
    int ICollection.Count => Count;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    bool IList.IsFixedSize => true;

    bool IList.IsReadOnly => IsReadOnly;

    object? IList.this[int index]
    {
        get => this[index];
        set => throw new NotSupportedException("JsonElement is read only.");
    }

    public void CopyTo(Array array, int index) => _data.ToArray().CopyTo(array, index);

    bool IList.Contains(object? value) => throw new NotImplementedException();

    int IList.IndexOf(object? value) => throw new NotImplementedException();

    int IList.Add(object? value) => throw new NotSupportedException("JsonElement is read only.");

    void IList.Clear() => throw new NotSupportedException("JsonElement is read only.");

    void IList.Insert(int index, object? value) => throw new NotSupportedException("JsonElement is read only.");

    void IList.Remove(object? value) => throw new NotSupportedException("JsonElement is read only.");

    void IList.RemoveAt(int index) => throw new NotSupportedException("JsonElement is read only.");
}