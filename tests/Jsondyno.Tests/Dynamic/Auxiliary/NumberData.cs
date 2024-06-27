using System.Numerics;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

public static class NumberData
{
    public static class Signed<TNumber>
        where TNumber : ISignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        public sealed class ZeroOneMinMax : TheoryData<TNumber>
        {
            public ZeroOneMinMax()
            {
                Add(TNumber.MinValue);
                Add(TNumber.Zero);
                Add(TNumber.One);
                Add(TNumber.MaxValue);
            }
        }

        public sealed class Random : TheoryData<TNumber>, ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize(new RandomPrimitives());
                var generator = fixture.Create<GenerateRandomBetweenDelegate<TNumber>>();

                Add(generator(MinNegative(), MaxNegative()));
                Add(generator(MinPositive(), MaxPositive()));

                fixture.InjectTheoryData(this);
            }

            private static TNumber MinNegative() => TNumber.MinValue + TNumber.One;

            private static TNumber MaxNegative() => -TNumber.One;

            private static TNumber MinPositive() => TNumber.CreateChecked(2);

            private static TNumber MaxPositive() => TNumber.MaxValue - TNumber.One;
        }
    }

    public static class Unsigned<TNumber>
        where TNumber : IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
    {
        public sealed class ZeroOneMax : TheoryData<TNumber>
        {
            public ZeroOneMax()
            {
                Add(TNumber.Zero);
                Add(TNumber.One);
                Add(TNumber.MaxValue);
            }
        }

        public sealed class Random : TheoryData<TNumber>, ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize(new RandomPrimitives());
                var generator = fixture.Create<GenerateRandomBetweenDelegate<TNumber>>();

                Add(generator(Min(), Max()));

                fixture.InjectTheoryData(this);
            }

            private static TNumber Min() => TNumber.CreateChecked(2);

            private static TNumber Max() => TNumber.MaxValue - TNumber.One;
        }
    }

    public static class Floating<TNumber>
        where TNumber : IFloatingPoint<TNumber>, IMinMaxValue<TNumber>
    {
        public sealed class ZeroOneMinMax : TheoryData<TNumber>
        {
            public ZeroOneMinMax()
            {
                Add(TNumber.MinValue);
                Add(TNumber.Zero);
                Add(TNumber.One);
                Add(TNumber.MaxValue);
            }
        }

        public sealed class Random : TheoryData<TNumber>, ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize(new RandomPrimitives());
                var generator = fixture.Create<GenerateRandomBetweenDelegate<TNumber>>();

                Add(generator(TNumber.MinValue, -TNumber.One));
                Add(generator(-TNumber.One, TNumber.Zero));
                Add(generator(TNumber.Zero, TNumber.One));
                Add(generator(TNumber.One, TNumber.MaxValue));

                fixture.InjectTheoryData(this);
            }
        }
    }
}