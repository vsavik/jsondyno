namespace Jsondyno.Tests.Misc;

internal sealed class ReferenceComparer<T> : IEqualityComparer<T>
    where T : class
{
    public bool Equals(T? x, T? y) => ReferenceEquals(x, y);

    public int GetHashCode(T obj) => obj.GetHashCode();

    public static IEqualityComparer<T> Create() => new ReferenceComparer<T>();
}