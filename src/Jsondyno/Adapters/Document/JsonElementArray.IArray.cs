using System.Collections;
using System.Collections.ObjectModel;

namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IArray
{
    public int Length { get; }

    public object? this[int index] => Data[index];

    public object?[] GetArray() => [..Data];

    public List<object?> GetList() => [..Data];

    public Collection<object?> GetCollection() => [..Data];

    public ArrayList GetArrayList() => new(Data);

    public LinkedList<object?> GetLinkedList() => new(Data);

    public HashSet<object?> GetHashSet() => [..Data];
}