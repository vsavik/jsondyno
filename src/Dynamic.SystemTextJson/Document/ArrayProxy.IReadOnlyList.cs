using System.Collections;

namespace Dynamic.SystemTextJson.Document;

partial class ArrayProxy : IReadOnlyList<object?>
{
    public int Count => Length;

    public object? this[int index] => _data[index];

    IEnumerator<object?> IEnumerable<object?>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}