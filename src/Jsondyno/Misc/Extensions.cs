namespace Jsondyno.Misc;

internal static class Extensions
{
    public static bool HasCustomConverterFor(this JsonSerializerOptions options, Type type)
    {
        IList<JsonConverter> converters = options.Converters;

        if (converters is [DynamicJsonConverter] or [])
        {
            return false;
        }

        bool result = false;
        Type? underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType is not null)
        {
            result = converters.HasCustomConverterFor(underlyingType);
        }

        if (!result)
        {
            result = converters.HasCustomConverterFor(type);
        }

        return result;
    }

    private static bool HasCustomConverterFor(this IList<JsonConverter> converters, Type type)
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

    public static bool IsCompatibleInterfaceTo(this Type targetType, Type sourceType) =>
        targetType.IsInterface && sourceType.IsAssignableTo(targetType);
}