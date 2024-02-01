using System.Collections;
using System.Collections.ObjectModel;

namespace Jsondyno.Adapters.Dynamic;

partial class ArrayAdapter
{
    public static implicit operator object?[]?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetArray());

    public static implicit operator List<object?>?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetList());

    public static implicit operator Collection<object?>?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetCollection());

    public static implicit operator ArrayList?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetArrayList());

    public static implicit operator LinkedList<object?>?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetLinkedList());

    public static implicit operator HashSet<object?>?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.GetHashSet());
}