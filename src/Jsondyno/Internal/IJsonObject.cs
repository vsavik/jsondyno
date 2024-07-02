namespace Jsondyno.Internal;

internal interface IJsonObject : IJsonValue
{
    IJsonValue? GetProperty(string key);
}