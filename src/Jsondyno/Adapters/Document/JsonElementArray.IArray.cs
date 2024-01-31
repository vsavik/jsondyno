using System.Collections;
using System.Collections.ObjectModel;

namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IArray
{
    public object?[] GetArray() => [.._data];

    public List<object?> GetList() => [.._data];

    public Collection<object?> GetCollection() => [.._data];

    public ArrayList GetArrayList() => new(_data);

    public LinkedList<object?> GetLinkedList() => new(_data);

    public HashSet<object?> GetHashSet() => [.._data];
}