using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class UnsignedRandomNumberData<TNumber> : TheoryData<TNumber>
    where TNumber : IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
{
    public UnsignedRandomNumberData(RandomGenerator<TNumber> generator)
    {
        Add(generator(MinPositive(), MaxPositive()));
    }

    private static TNumber MinPositive() => TNumber.CreateChecked(2);

    private static TNumber MaxPositive() => TNumber.MaxValue - TNumber.One;
}