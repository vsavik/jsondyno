namespace Jsondyno.Adapters;

internal interface IPrimitive : IValue, IValue<IPrimitive>
{
    string? GetString();
}