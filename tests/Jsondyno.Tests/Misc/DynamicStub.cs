using System.Dynamic;

namespace Jsondyno.Tests.Misc;

internal sealed class DynamicStub<T> : DynamicObject
    where T : notnull
{
    private readonly T _value;

    public DynamicStub(T value)
    {
        _value = value;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        if (typeof(T) == binder.ReturnType)
        {
            result = _value;

            return true;
        }

        result = null;

        return false;
    }
}