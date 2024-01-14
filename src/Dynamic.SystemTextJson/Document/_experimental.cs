

using System.Collections;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Dynamic.SystemTextJson.Document;






public interface IConverterProxy
{
    TOut As<TOut>();

    TOut To<TOut>();
}

public static class ConverterExtensions
{
    // MaybeNull input, allow return null
    public static TOut As<TOut>(dynamic src, TOut defaultValue)
    {
        if (src is IConverterProxy proxy)
        {
            return proxy.As<TOut>();
        }

        return default!;
    }
}

public interface IJsonProxy<in T>
    where T : IJsonProxy<T>
{
    static abstract implicit operator JsonDocument?(T proxy);

    static abstract implicit operator JsonElement(T proxy);

    static abstract implicit operator JsonNode(T proxy);

    static abstract implicit operator JsonValue(T proxy);

    static abstract implicit operator JsonArray(T proxy);

    static abstract implicit operator JsonObject(T proxy);
}

public interface IValueProxy<in T>
    where T : IValueProxy<T>
{
    static abstract implicit operator string?(T proxy);

    static abstract implicit operator Guid(T proxy);

    static abstract implicit operator Guid?(T proxy);

    static abstract implicit operator DateTime(T proxy);

    static abstract implicit operator DateTime?(T proxy);

    static abstract implicit operator DateTimeOffset(T proxy);

    static abstract implicit operator DateTimeOffset?(T proxy);

    static abstract implicit operator byte[]?(T proxy);
}

public interface IStringProxy<in T>
    where T : IStringProxy<T>
{
    static abstract implicit operator string?(T proxy);
}



namespace Dyno.Value
{
    public class A
    {

    }

}

namespace Dyno.Value.Child
{
    public class B
    {
        A a = new A();

    }
}