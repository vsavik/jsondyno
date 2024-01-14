namespace Dynamic.SystemTextJson.Document;

partial class ValueProxy
{
    public static implicit operator Boolean(ValueProxy proxy) =>
        proxy.GetValue(BooleanFunctions.LoadBoolean);

    public static implicit operator Boolean?(ValueProxy proxy) =>
        (bool)proxy;

    private static class BooleanFunctions
    {
        public static LoadValueDelegate<bool> LoadBoolean { get; } =
            static (in JsonElement element) => element.GetBoolean();
    }
}