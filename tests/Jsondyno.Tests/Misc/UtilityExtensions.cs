namespace Jsondyno.Tests.Misc;

internal static class UtilityExtensions
{
    public static string Description(this Type type)
    {
        Type? nullable = Nullable.GetUnderlyingType(type);

        return nullable is not null ? $"Nullable<{nullable.Name}>" : type.Name;
    }

    public static void Deconstruct<T>(this IEnumerable<T> sequence, out T first, out T second)
    {
        using IEnumerator<T> enumerator = sequence.GetEnumerator();

        enumerator.MoveNext();
        first = enumerator.Current;

        enumerator.MoveNext();
        second = enumerator.Current;
    }
}