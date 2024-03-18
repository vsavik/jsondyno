namespace Jsondyno.Internal.Dynamic;

public sealed partial class ObjectAdapter : DynamicObject
{
    private readonly IJsonObject _value;

    private readonly Context _context;

    private Dictionary<string, object?>? _cache;

    internal ObjectAdapter(IJsonObject value, Context context)
    {
        _value = value;
        _context = context;
    }

    public object? this[string key] => _value
        .GetObjectProperty(key)?
        .ToDynamic(_context);

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        result = _value.Deserialize(binder.ReturnType, _context.Options);

        return true;
    }

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

    public override string ToString() => _value.ToString()!;
}