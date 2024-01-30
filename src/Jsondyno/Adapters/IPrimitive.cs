namespace Jsondyno.Adapters;

internal interface IPrimitive : IValue, IValue<IPrimitive>
{
    string AsString();
}