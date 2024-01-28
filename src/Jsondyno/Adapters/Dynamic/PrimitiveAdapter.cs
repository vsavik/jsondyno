namespace Jsondyno.Adapters.Dynamic;

internal sealed class PrimitiveAdapter : ValueAdapter<IPrimitive>
{
    public PrimitiveAdapter(IPrimitive value)
        : base(value)
    {
    }

    public static implicit operator string?(PrimitiveAdapter adapter) =>
        adapter.Value.ConvertTo(static x => x.GetString());
}