using System.Diagnostics;

namespace Jsondyno.Adapters.Node;

// TBD
internal class NodeValue : IValue
{
    public object? ConvertTo(Type targetType) => throw new NotImplementedException();
}

internal class NodePrimitive : IValue
{
    public object? ConvertTo(Type targetType) => throw new NotImplementedException();
}

internal class NodeObject : IValue
{
    public object? ConvertTo(Type targetType) => throw new NotImplementedException();
}

internal class NodeArray : IValue
{
    public object? ConvertTo(Type targetType) => throw new NotImplementedException();
}