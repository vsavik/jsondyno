namespace Jsondyno.Tests.Adapters.Dynamic;

internal static class ValueAdapterMockExtensions
{
    public static void JsondynoSetupTypecast<TMock, TValue>(
        this Mock<TMock> mock,
        Expression<Func<TMock, TValue>> expression,
        TValue value)
        where TMock : class, IValue, IValue<TMock>
        where TValue : notnull
    {
        mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(TValue))))
            .Throws(() => new InvalidOperationException(
                $"{nameof(IValue.ConvertTo)} shoud not be called for typecast operations."));

        mock.Setup(x => x.ConvertUsing(It.IsAny<ValueConverter<TMock, TValue>>()))
            .Returns((ValueConverter<TMock, TValue> converter) => converter(mock.Object));

        mock.Setup(expression).Returns(value);
    }

    public static void JsondynoVerifyTypecast<TMock, TValue>(
        this Mock<TMock> mock,
        Expression<Func<TMock, TValue>> expression)
        where TMock : class, IValue, IValue<TMock>
        where TValue : notnull
    {
        mock.Verify(
            x => x.ConvertTo(It.IsAny<Type>()),
            Times.Never(),
            $"{nameof(IValue.ConvertTo)} shoud not be called for typecast operations.");

        mock.Verify(
            x => x.ConvertUsing(It.IsAny<ValueConverter<TMock, TValue>>()),
            Times.Once(),
            $"{nameof(IValue<TMock>.ConvertUsing)} shoud not be called only once.");

        mock.Verify(expression, Times.Once(), "Data action should be called only once.");
    }

    public static void JsondynoSetupTypeConversion<TMock, TValue>(
        this Mock<TMock> mock,
        TValue value)
        where TMock : class, IValue, IValue<TMock>
    {
        mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(TValue))))
            .Returns(value);
    }

    public static void JsondynoVerifyTypeConversion<TMock>(this Mock<TMock> mock)
        where TMock : class, IValue, IValue<TMock>
    {
        mock.Verify(
            x => x.ConvertTo(It.IsAny<Type>()),
            Times.Once(),
            $"{nameof(IValue.ConvertTo)} shoud be called only once.");
    }
}