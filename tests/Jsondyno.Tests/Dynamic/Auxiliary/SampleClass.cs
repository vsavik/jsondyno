namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class SampleClass
{
    private readonly string _value;

    public SampleClass(string value)
    {
        _value = value;
    }

    public override string ToString() => $"Sample class ({_value})";
}