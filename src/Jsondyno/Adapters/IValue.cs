namespace Jsondyno.Adapters;

internal interface IValue
{
    object? ConvertTo(Type targetType);
}

internal interface IValue<out TValue>
    where TValue : IValue<TValue>
{
    TResult? ConvertUsing<TResult>(ValueConverter<TValue, TResult> converter)
        where TResult : notnull;
}

internal delegate TResult ValueConverter<in TValue, out TResult>(TValue value)
    where TResult : notnull;