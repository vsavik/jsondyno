using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Adapters.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed partial class ObjectAdapter : ValueAdapter<IObject>
{
    public ObjectAdapter(IObject value)
        : base(value)
    {
    }

    public int Count => Value.Count;

    public object? this[string key] => Value.GetByRawKey(key);

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        string key = binder.Name;
        result = Value.GetByKey(key);

        return true;
    }
}