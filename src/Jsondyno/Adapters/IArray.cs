using System.Collections;

namespace Jsondyno.Adapters;

internal interface IArray : IValue, IValue<IArray>
{
    object? this[int index] { get; }

    int Length { get; }

    int Count { get; }

    object?[] GetArray();

    List<object?> GetList();

    ArrayList GetArrayList();

    LinkedList<object?> GetLinkedList();

    HashSet<object?> GetHashSet();
}