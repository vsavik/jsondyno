namespace Jsondyno.Tests.Misc;

public static class TypeExtensions
{
    public static string ToPrettyString(this Type type)
    {
        Type? nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType is not null)
        {
            return $"{nullableType.ToPrettyString()}?";
        }

        if (type.IsArray)
        {
            return $"{type.GetElementType()?.ToPrettyString()}[]";
        }

        if (type.IsGenericType)
        {
            return $"{type.ExtractGenericTypeName()}<{type.ExtractGenericTypeArgs()}>";
        }

        if (type.IsNested)
        {
            return $"{type.DeclaringType?.ToPrettyString()}.{type.Name}";
        }

        return type.Name;
    }

    private static string ExtractGenericTypeName(this Type type)
    {
        string name = type.Name;
        int index = name.IndexOf('`');
        if (index < 0)
        {
            throw new InvalidOperationException($"Type {type.Namespace}.{type.Name} is not generic.");
        }

        return name[..index];
    }

    private static string ExtractGenericTypeArgs(this Type type)
    {
        IEnumerable<string> typeArgs = type.GetGenericArguments()
            .Select(arg => arg.ToPrettyString());

        return String.Join(", ", typeArgs);
    }
}