namespace Jsondyno.Adapters.Document;

internal abstract class JsonElementValue<TValue> : IValue, IValue<TValue>
    where TValue : IValue<TValue>
{
    private readonly JsonElement _element;

    private ValueCache _cache;

    protected JsonElementValue(in JsonElement element, JsonSerializerOptions options)
    {
        _element = element;
        Options = options;
    }

    protected ref readonly JsonElement Element => ref _element;

    protected JsonSerializerOptions Options { get; }

    protected abstract TValue Self { get; }

    public object? ConvertTo(Type targetType)
    {
        // If compatible type was already requested, get it from cache
        if (_cache.TryGetValue(targetType, out object? result))
        {
            return result;
        }

        // In case when custom converter exists, prefer it instead of JsonElement::GetXxx methods
        if (targetType.HasCustomConverter(Options))
        {
            return _cache.SetValue(_element.Deserialize(targetType, Options));
        }

        // If JsonElementAdapter child class is compatible with requested one 
        if (targetType.IsCompatibleInterfaceTo(GetType()))
        {
            return _cache.SetValue(this);
        }

        // Deserialize unknown type/enum or fail conversion.
        return _cache.SetValue(_element.Deserialize(targetType, Options));
    }

    public TResult? ConvertUsing<TResult>(ValueConverter<TValue, TResult> converter)
        where TResult : notnull
    {
        Type targetType = typeof(TResult);

        // If compatible type was already requested
        if (_cache.TryGetValue(targetType, out TResult? result))
        {
            return result;
        }

        // In case when custom converter exists, prefer it GetXxx methods
        if (targetType.HasCustomConverter(Options))
        {
            return _cache.SetValue(_element.Deserialize<TResult>(Options));
        }

        // Some known type was requested,like Int32 or List<object?> 
        return _cache.SetValue(converter(Self));
    }

    private struct ValueCache
    {
        private object? _value;

        private bool _isSet;

        public bool TryGetValue<T>(Type targetType, out T? value)
        {
            if (_isSet)
            {
                if (_value is null || _value.GetType().IsCompatibleWith(targetType))
                {
                    value = (T?)_value;

                    return true;
                }
            }

            value = default;

            return false;
        }

        public T SetValue<T>(T value)
        {
            _value = value;
            _isSet = true;

            return value;
        }
    }
}