namespace Jsondyno.Adapters.Dynamic;

internal sealed class ArrayAdapter : ValueAdapter<IArray>
{
    public ArrayAdapter(IArray value)
        : base(value)
    {
    }

    public static implicit operator List<object?>?(ArrayAdapter adapter) =>
        adapter.Value.ConvertUsing(static x => x.AsList());
}