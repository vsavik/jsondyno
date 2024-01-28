namespace Jsondyno.Adapters.Dynamic;

internal abstract class ValueAdapter<TValue> : DynamicObject
    where TValue : IValue, IValue<TValue>
{
    protected ValueAdapter(TValue value)
    {
        Value = value;
    }

    protected TValue Value { get; }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = Value.ConvertTo(binder.ReturnType);

        return true;
    }
}