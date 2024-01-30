using Jsondyno.Adapters.Document;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Adapters;

internal static class DynamicAdapterFactory
{
    public static object? CreateAdapter(this in JsonElement element, JsonSerializerOptions options)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.String:
            case JsonValueKind.Number:
                var primitive = new JsonElementPrimitive(element, options);
                return new PrimitiveAdapter(primitive);

            case JsonValueKind.Array:
                var array = new JsonElementArray(element, options);
                return new ArrayAdapter(array);

            case JsonValueKind.Object:
                var obj = new JsonElementObject(element, options);
                return new ObjectAdapter(obj);

            case JsonValueKind.Null:
                return null;

            case JsonValueKind.Undefined:
            default:
                throw new InvalidOperationException(SR.CannotCreateDynamicAdapter(element.ValueKind));
        }
    }
}