using System.Diagnostics.CodeAnalysis;

namespace Jsondyno.Internal.Dynamic;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal sealed class ObjectAdapter : DynamicAdapter<IJsonObject>
{
    private Dictionary<string, object?>? _cache;

    public ObjectAdapter(IJsonObject value, Context context)
        : base(value, context)
    {
    }

    public object? this[string key] => _value
        .GetObjectProperty(key)?
        .ToDynamic(_context);

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = GetPropertyValue(binder.Name);

        return true;
    }

    private object? GetPropertyValue(string propertyName)
    {
        _cache ??= new Dictionary<string, object?>(_context.ObjectKeyComparer);
        if (_cache.TryGetValue(propertyName, out object? propertyValue))
        {
            return propertyValue;
        }

        string key = _context.ConvertPropertyNameToKey(propertyName);
        propertyValue = _value.GetObjectProperty(key, _context.ObjectKeyComparer)?.ToDynamic(_context);
        _cache.Add(propertyName, propertyValue);

        return propertyValue;
    }
}