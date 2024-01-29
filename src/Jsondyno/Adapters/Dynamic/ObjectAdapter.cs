namespace Jsondyno.Adapters.Dynamic;

internal sealed class ObjectAdapter : ValueAdapter<IObject>
{
    public ObjectAdapter(IObject value)
        : base(value)
    {
    }
}