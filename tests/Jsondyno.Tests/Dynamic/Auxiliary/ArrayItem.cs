namespace Jsondyno.Tests.Dynamic.Auxiliary;

public readonly struct ArrayItem
{
    public ArrayItem(int index, string value)
    {
        Index = index;
        Value = value;
    }

    public int Index { get; }

    public string Value { get; }

    public override string ToString() => $"[{Index}, '{Value}']";
}