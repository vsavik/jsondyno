namespace Jsondyno.Adapters;

internal interface IValue
{
    object? ConvertTo(Type targetType);
}

internal interface IValue<out TValue>
    where TValue : IValue<TValue>
{
    TResult? ConvertTo<TResult>(Converter<TValue, TResult> converter);
}

internal delegate TResult Converter<in TValue, out TResult>(TValue adapter);