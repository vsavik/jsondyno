using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public abstract class NumberData<TSelf, TNumber> : TheoryData<TNumber>
    where TSelf : NumberData<TSelf, TNumber>, new()
    where TNumber : INumberBase<TNumber>, IMinMaxValue<TNumber>
{
    private Faker? _faker;

    protected Faker Faker => _faker ??= new Faker();

    protected abstract TNumber GenerateRandom(TNumber min, TNumber max);

    private TSelf AddRange(IEnumerable<TNumber> numbers)
    {
        foreach (TNumber number in numbers)
        {
            Add(number);
        }

        return (TSelf)this;
    }

    private TSelf AddRandom(TNumber min, TNumber max)
    {
        TNumber number = GenerateRandom(min, max);
        Add(number);

        return (TSelf)this;
    }

    public static TheoryData<TNumber> SignedIntegralMinMaxZeroOne() => new TSelf()
        .AddRange([TNumber.MinValue, TNumber.MaxValue, TNumber.Zero, TNumber.One]);

    public static TheoryData<TNumber> UnsignedIntegralZeroMaxOne() => new TSelf()
        .AddRange([TNumber.Zero, TNumber.MaxValue, TNumber.One]);

    public static TheoryData<TNumber> SignedIntegralRandomPositive() => new TSelf()
        .AddRandom(MinPositive(), MaxPositive());

    public static TheoryData<TNumber> SignedIntegralRandomNegative() => new TSelf()
        .AddRandom(MinNegative(), MaxNegative());

    public static TheoryData<TNumber> UnsignedIntegralRandom() => new TSelf()
        .AddRandom(MinPositive(), MaxPositive());

    private static TNumber MinNegative() => TNumber.MinValue + TNumber.One;

    private static TNumber MaxNegative() => -TNumber.One;

    private static TNumber MinPositive() => TNumber.CreateChecked(2);

    private static TNumber MaxPositive() => TNumber.MaxValue - TNumber.One;

    public static TheoryData<TNumber> FloatingMinMaxZeroOne() => new TSelf()
        .AddRange([TNumber.MinValue, TNumber.MaxValue, TNumber.Zero, TNumber.One]);

    public static TheoryData<TNumber> FloatingRandomPositiveAboveOne() => new TSelf()
        .AddRandom(TNumber.One, TNumber.MaxValue);

    public static TheoryData<TNumber> FloatingRandomPositiveBelowOne() => new TSelf()
        .AddRandom(TNumber.Zero, TNumber.One);

    public static TheoryData<TNumber> FloatingRandomNegativeBelowOne() => new TSelf()
        .AddRandom(TNumber.MinValue, -TNumber.One);

    public static TheoryData<TNumber> FloatingRandomNegativeAboveOne() => new TSelf()
        .AddRandom(-TNumber.One, TNumber.Zero);
}