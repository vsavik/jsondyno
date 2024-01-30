using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementArray : IArray
{
    public List<object?> AsList() => throw new NotImplementedException();
    
    public object?[] GetArray() => throw new NotImplementedException();

    public List<object?> GetList() => throw new NotImplementedException();

    public ArrayList GetArrayList() => throw new NotImplementedException();

    public LinkedList<object?> GetLinkedList() => throw new NotImplementedException();

    public HashSet<object?> GetHashSet() => throw new NotImplementedException();
}