using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Adapters.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed partial class ArrayAdapter : ValueAdapter<IArray>
{
    public ArrayAdapter(IArray value)
        : base(value)
    {
    }

    public int Length => Value.Length;

    public int Count => Value.Count;

    public object? this[int index] => Value[index];
}