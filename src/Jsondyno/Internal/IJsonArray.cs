namespace Jsondyno.Internal;

internal interface IJsonArray : IJsonValue
{
    int GetLength();

    IJsonValue? GetArrayElement(int index);
}