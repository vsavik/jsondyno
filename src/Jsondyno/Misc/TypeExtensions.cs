namespace Jsondyno.Misc;

internal static class TypeExtensions
{
    public static bool HasCustomConverter(this Type type, JsonSerializerOptions options)
    {
        IList<JsonConverter> converters = options.Converters;

        if (converters is [DynamicObjectJsonConverter] or [])
        {
            return false;
        }

        bool result = false;
        Type? underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType is not null)
        {
            result = underlyingType.HasCustomConverter(converters);
        }

        if (!result)
        {
            result = type.HasCustomConverter(converters);
        }

        return result;
    }

    private static bool HasCustomConverter(this Type type, IList<JsonConverter> converters)
    {
        // This is to avoid GetEnumerator memory allocation.
        // ReSharper disable once ForCanBeConvertedToForeach
        for (int i = 0; i < converters.Count; i++)
        {
            if (converters[i].CanConvert(type))
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsCompatibleWith(this Type sourceType, Type targetType)
    {
        // If targetType matches cached value type, then ok to return cached value 
        if (sourceType == targetType)
        {
            return true;
        }

        // If targetType is interface like IEnumerable<T> and source type is List<T>
        if (targetType.IsCompatibleInterfaceTo(sourceType))
        {
            return true;
        }

        // If target type is Nullable<T> and source type is just T struct
        Type? underlyingTargetType = Nullable.GetUnderlyingType(targetType);

        return underlyingTargetType is not null && sourceType == underlyingTargetType;
    }

    public static bool IsCompatibleInterfaceTo(this Type abstraction, Type implementation) =>
        abstraction.IsInterface && implementation.IsAssignableTo(abstraction);
}