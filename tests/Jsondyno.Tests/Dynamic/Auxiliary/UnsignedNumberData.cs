using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class UnsignedNumberData<TNumber> : TheoryData<TNumber>
    where TNumber : IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
{
    public UnsignedNumberData()
    {
        Add(TNumber.Zero);
        Add(TNumber.One);
        Add(TNumber.MaxValue);
    }
}