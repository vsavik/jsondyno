namespace Dynamic.SystemTextJson.Document;

partial class ValueProxy
{
    public static implicit operator string?(ValueProxy proxy) =>
        proxy.GetValue(StringFunctions.LoadString);

    /*

    public static implicit operator Guid(T proxy);

    public static implicit operator Guid?(T proxy);

    public static implicit operator DateTime(T proxy);

    public static implicit operator DateTime?(T proxy);

    public static implicit operator DateTimeOffset(T proxy);

    public static implicit operator DateTimeOffset?(T proxy);

    public static implicit operator byte[]?(T proxy);*/

    private static class StringFunctions
    {
        public static LoadValueDelegate<string?> LoadString { get; } =
            static (in JsonElement element) => element.GetString();
    }
}