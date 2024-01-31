using System.Collections;

namespace Jsondyno.Adapters;

internal interface IObject : IValue, IValue<IObject>
{
    int Count { get; }

    object? this[string key] { get; }

    Dictionary<string, object?> GetDictionary();

    Hashtable GetHashtable();
}