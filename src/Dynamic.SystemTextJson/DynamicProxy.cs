using Dynamic.SystemTextJson.Document;

namespace Dynamic.SystemTextJson;

public static class DynamicProxy
{
    internal static DocumentProxy? CreateProxy(this in JsonElement element, JsonSerializerOptions options)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.String:
            case JsonValueKind.Number:
                return new ValueProxy(in element, options);

            case JsonValueKind.Array:
                return new ArrayProxy(in element, options);

            case JsonValueKind.Object:
                return new ObjectProxy(in element, options);

            case JsonValueKind.Null:
                return null;

            case JsonValueKind.Undefined:
            default:
                throw new InvalidOperationException(
                    $"Cannot create proxy object for value kind {element.ValueKind}.");
        }
    }
    
    public static dynamic? AsDynamic(this JsonDocument document, JsonSerializerOptions? options = null)
    {
        return CreateProxy(document.RootElement, options ?? JsonSerializerOptions.Default);
    }
    
    public static dynamic? AsDynamic(this in JsonElement element, JsonSerializerOptions? options = null)
    {
        return CreateProxy(element, options ?? JsonSerializerOptions.Default);
    }
    
    /*public static TOut As<TIn, TOut>(this TIn obj)
    {
        if (obj == null)
        {
            return null;
        }
    }*/
        
    public static TOut As<TOut>(this object? obj)
    {
        Dynamic.Test();
        if (obj == null)
        {
        }
        return default!;
    }
}


public static class Dynamic
{
    public static void Test()
    {
        
    }
}


