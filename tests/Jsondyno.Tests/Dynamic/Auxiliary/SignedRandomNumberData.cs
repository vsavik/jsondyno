using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class SignedRandomNumberData<TNumber> : TheoryData<TNumber>
    where TNumber : ISignedNumber<TNumber>, IMinMaxValue<TNumber>
{
    public SignedRandomNumberData(RandomGenerator<TNumber> generator)
    {
        Add(generator(MinNegative(), MaxNegative()));
        Add(generator(MinPositive(), MaxPositive()));
    }

    private static TNumber MinNegative() => TNumber.MinValue + TNumber.One;

    private static TNumber MaxNegative() => -TNumber.One;

    private static TNumber MinPositive() => TNumber.CreateChecked(2);

    private static TNumber MaxPositive() => TNumber.MaxValue - TNumber.One;
}