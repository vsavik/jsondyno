namespace Jsondyno.Adapters.Dynamic;

internal sealed partial class PrimitiveAdapter : ValueAdapter<IPrimitive>
{
    public PrimitiveAdapter(IPrimitive value)
        : base(value)
    {
    }
}