using Jsondyno.Adapters;

namespace Jsondyno.Tests.Adapters.Dynamic;

internal sealed class DynamicAdapterFixture<TMock>
    where TMock : class, IValue, IValue<TMock>
{
    public Mock<TMock> Mock { get; } = new(MockBehavior.Strict);

    public DynamicAdapterFixture<TMock> SetupCast<TValue>(
        Expression<Func<TMock, TValue>> expression,
        TValue value)
        where TValue : notnull
    {
        Mock.Setup(x => x.ConvertTo(It.Is<Type>(type => type == typeof(TValue))))
            .Throws(() => new InvalidOperationException(
                $"{nameof(IValue.ConvertTo)} shoud not be called for typecast operations."));

        Mock.Setup(x => x.ConvertUsing(It.IsAny<ValueConverter<TMock, TValue>>()))
            .Returns((ValueConverter<TMock, TValue> converter) => converter(Mock.Object));

        Mock.Setup(expression).Returns(value);

        return this;
    }

    public void Verify<TValue>(Expression<Func<TMock, TValue>> expression)
        where TValue : notnull
    {
        Mock.Verify(
            x => x.ConvertTo(It.IsAny<Type>()),
            Times.Never(),
            $"{nameof(IValue.ConvertTo)} shoud not be called for typecast operations.");

        Mock.Verify(
            x => x.ConvertUsing(It.IsAny<ValueConverter<TMock, TValue>>()),
            Times.Once(),
            $"{nameof(IValue<TMock>.ConvertUsing)} shoud not be called only once.");

        Mock.Verify(expression, Times.Once(), "Data action should be called only once.");
    }
}