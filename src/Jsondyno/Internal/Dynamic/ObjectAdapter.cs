using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed class ObjectAdapter : DynamicObject
{
    private readonly IJsonObject _value;

    private readonly Context _context;

    private Dictionary<string, object?>? _cache;

    public ObjectAdapter(IJsonObject value, Context context)
    {
        _value = value;
        _context = context;
    }

    public object? this[string key] => _value
        .GetObjectPropertyCaseSensitive(key)?
        .ToDynamic(_context);

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = GetPropertyValue(binder.Name);

        return true;
    }

    public object? GetPropertyValue(string propertyName)
    {
        _cache ??= new Dictionary<string, object?>(_context.ObjectKeyStrategy.Comparer);
        if (_cache.TryGetValue(propertyName, out object? propertyValue))
        {
            return propertyValue;
        }

        string key = _context.ConvertPropertyNameToKey(propertyName);
        propertyValue = _context.ObjectKeyStrategy
            .LoadJsonValue(_value, key)?.ToDynamic(_context);

        _cache.Add(propertyName, propertyValue);

        return propertyValue;
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value.Deserialize(binder.ReturnType, _context.Options);

        return true;
    }
}