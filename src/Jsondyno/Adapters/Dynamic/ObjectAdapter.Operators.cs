using System.Collections;

namespace Jsondyno.Adapters.Dynamic;

partial class ObjectAdapter
{
    public static implicit operator Dictionary<string, object?>?(ObjectAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetDictionary());

    public static implicit operator Hashtable?(ObjectAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetHashtable());
}