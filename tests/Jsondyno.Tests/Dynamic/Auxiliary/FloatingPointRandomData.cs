using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class FloatingPointRandomData<TNumber> : TheoryData<TNumber>
    where TNumber : ISignedNumber<TNumber>, IMinMaxValue<TNumber>
{
    public FloatingPointRandomData(RandomGenerator<TNumber> generator)
    {
        Add(generator(TNumber.MinValue, -TNumber.One));
        Add(generator(-TNumber.One, TNumber.Zero));
        Add(generator(TNumber.Zero, TNumber.One));
        Add(generator(TNumber.One, TNumber.MaxValue));
    }
}