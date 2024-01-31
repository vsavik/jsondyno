using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementObject : IObject
{
    public int Count => throw new NotImplementedException();

    public object? GetByKey(string key) => throw new NotImplementedException();

    public object? GetByRawKey(string key) => throw new NotImplementedException();

    public Dictionary<string, object?> GetDictionary() => throw new NotImplementedException();

    public Hashtable GetHashtable() => throw new NotImplementedException();
}