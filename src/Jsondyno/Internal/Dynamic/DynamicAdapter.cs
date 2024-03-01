using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal abstract partial class DynamicAdapter<TJsonValue> : DynamicObject
    where TJsonValue : IJsonValue
{
    protected readonly TJsonValue _value;

    protected readonly Context _context;

    protected DynamicAdapter(TJsonValue value, Context context)
    {
        _value = value;
        _context = context;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value.Deserialize(binder.ReturnType, _context.Options);

        return true;
    }

    public override string ToString() => _value.ToString()!;
}