namespace Jsondyno.Tests.Dynamic.Auxiliary;

public readonly struct SampleStruct
{
    private readonly int _value;

    public SampleStruct(int value)
    {
        _value = value;
    }

    public override string ToString() => $"Sample struct ({_value})";
}