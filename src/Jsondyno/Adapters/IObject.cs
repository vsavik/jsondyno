using System.Collections;

namespace Jsondyno.Adapters;

internal interface IObject : IValue, IValue<IObject>
{
    int Count { get; }

    object? GetByKey(string key);

    object? GetByRawKey(string key);

    Dictionary<string, object?> GetDictionary();

    Hashtable GetHashtable();
}