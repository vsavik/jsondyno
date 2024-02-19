namespace Jsondyno.Internal;

internal interface IJsonObject : IJsonValue
{
    IJsonValue? GetObjectPropertyCaseSensitive(string key);

    IJsonValue? GetObjectPropertyCaseInsensitive(string key);
}