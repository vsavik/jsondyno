using System.Collections;

namespace Jsondyno.Adapters.Dynamic;

partial class ObjectAdapter
{
    public static implicit operator Dictionary<string, object?>?(ObjectAdapter adapter) =>
        throw new NotImplementedException();

    public static implicit operator Hashtable?(ObjectAdapter adapter) =>
        throw new NotImplementedException();
}