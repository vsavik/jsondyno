using System.Collections;

namespace Jsondyno.Adapters.Document;

partial class JsonElementObject : IObject
{
    public Dictionary<string, object?> GetDictionary() => throw new NotImplementedException();

    public Hashtable GetHashtable() => throw new NotImplementedException();
}