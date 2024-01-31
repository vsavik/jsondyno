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

    public object? this[string key] => Value[key];

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        //
        return base.TryGetMember(binder, out result);
    }
}