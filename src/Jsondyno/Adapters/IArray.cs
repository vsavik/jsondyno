namespace Jsondyno.Adapters;

internal interface IArray : IValue, IValue<IArray>
{
    List<object?> ToList();
}