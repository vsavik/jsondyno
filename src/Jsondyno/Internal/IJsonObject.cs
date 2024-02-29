namespace Jsondyno.Internal;

internal interface IJsonObject : IJsonValue
{
    IJsonValue? GetObjectProperty(string key);

    IJsonValue? GetObjectProperty(string key, StringComparer comparer) =>
        GetObjectProperty(key);
}