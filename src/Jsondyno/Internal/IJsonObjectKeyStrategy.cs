namespace Jsondyno.Internal;

internal interface IJsonObjectKeyStrategy
{
    StringComparer Comparer { get; }

    IJsonValue? LoadJsonValue(IJsonObject jsonObject, string key);
}