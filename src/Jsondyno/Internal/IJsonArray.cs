namespace Jsondyno.Internal;

internal interface IJsonArray : IJsonValue
{
    int GetLength();

    IJsonValue? GetElement(int index);
}