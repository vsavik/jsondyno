using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public sealed class SignedNumberData<TNumber> : TheoryData<TNumber>
    where TNumber : ISignedNumber<TNumber>, IMinMaxValue<TNumber>
{
    public SignedNumberData()
    {
        Add(TNumber.MinValue);
        Add(TNumber.Zero);
        Add(TNumber.One);
        Add(TNumber.MaxValue);
    }
}