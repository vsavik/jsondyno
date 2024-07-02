using System.Dynamic;

namespace Jsondyno.Tests.Misc;

internal sealed class DynamicStub : DynamicObject
{
    private readonly string _value;

    public DynamicStub(string value)
    {
        _value = value;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value;

        return true;
    }
}