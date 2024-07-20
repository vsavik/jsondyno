using Jsondyno.Internal;

namespace Jsondyno.Dynamic;

/// <summary>
///   Represents a dynamic adapter to wrap JSON obejcts.
/// </summary>
public sealed class ObjectAdapter : Adapter
{
    private readonly IJsonObject _value;

    private readonly JsonNamingPolicy? _policy;

    private Dictionary<string, object?>? _cache;

    internal ObjectAdapter(IJsonObject value, JsonNamingPolicy? policy)
    {
        _value = value;
        _policy = policy;
    }

    private protected override IJsonValue JsonValue => _value;

    /// <summary>
    ///   Gets the element with the specified property name.
    ///   If the property is not found, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="key">The name of the property to return.</param>
    public object? this[string key] => GetPropertyByIndex(key);

    private object? GetPropertyByIndex(string key)
    {
        if (TryGetFromCache(key, out object? propertyValue))
        {
            return propertyValue;
        }

        propertyValue = _value.GetProperty(key)?.ToDynamic();
        _cache.Add(key, propertyValue);

        return propertyValue;
    }

    /// <inheritdoc />
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = GetPropertyByMemberName(binder.Name);

        return true;
    }

    private object? GetPropertyByMemberName(string propertyName)
    {
        if (TryGetFromCache(propertyName, out object? propertyValue))
        {
            return propertyValue;
        }

        string key = _policy?.ConvertName(propertyName) ?? propertyName;
        propertyValue = _value.GetProperty(key)?.ToDynamic();
        _cache.Add(propertyName, propertyValue);

        return propertyValue;
    }

    [MemberNotNull(nameof(_cache))]
    private bool TryGetFromCache(string propertyName, out object? propertyValue)
    {
        _cache ??= new Dictionary<string, object?>(StringComparer.Ordinal);

        return _cache.TryGetValue(propertyName, out propertyValue);
    }
}