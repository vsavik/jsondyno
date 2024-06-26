namespace Jsondyno.Tests.Misc;

internal static class LocalExtensions
{
    public static string Description(this Type type)
    {
        Type? nullable = Nullable.GetUnderlyingType(type);

        return nullable is not null ? $"Nullable<{nullable.Name}>" : type.Name;
    }
}