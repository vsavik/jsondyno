using System.Numerics;

namespace Jsondyno.Tests.Dynamic;

partial class PrimitiveAdapterTestFixture
{
    private sealed class TheoryDataBuilder : TheoryData<IValue>
    {
        private TheoryDataBuilder()
        {
        }

        public static TheoryDataBuilder New => new();

        public TheoryDataBuilder AddBooleanSource() =>
            AddValueType(true).AddValueType(false);

        public TheoryDataBuilder AddStaticNumberSource()
        {
            AddSignedNumberSource<sbyte>();
            AddUnsignedNumberSource<byte>();
            AddSignedNumberSource<short>();
            AddUnsignedNumberSource<ushort>();
            AddSignedNumberSource<int>();
            AddUnsignedNumberSource<uint>();
            AddSignedNumberSource<long>();
            AddUnsignedNumberSource<ulong>();
            AddSignedNumberSource<float>();
            AddSignedNumberSource<double>();
            AddSignedNumberSource<decimal>();

            return this;
        }

        private void AddSignedNumberSource<TNumber>()
            where TNumber : struct, ISignedNumber<TNumber>, IMinMaxValue<TNumber>
        {
            AddValueType(TNumber.Zero);
            AddValueType(TNumber.One);
            AddValueType(TNumber.MinValue);
            AddValueType(TNumber.MaxValue);
        }

        private void AddUnsignedNumberSource<TNumber>()
            where TNumber : struct, IUnsignedNumber<TNumber>, IMinMaxValue<TNumber>
        {
            AddValueType(TNumber.One);
            AddValueType(TNumber.MinValue);
            AddValueType(TNumber.MaxValue);
        }

        public TheoryDataBuilder AddRandomNumberSource()
        {
            static T MinNegative<T>() where T : ISignedNumber<T>, IMinMaxValue<T> => T.MinValue + T.One;

            static T MaxNegative<T>() where T : ISignedNumber<T>, IMinMaxValue<T> => -T.One;

            static T MinPositive<T>() where T : INumberBase<T>, IMinMaxValue<T> => T.CreateChecked(2);

            static T MaxPositive<T>() where T : INumberBase<T>, IMinMaxValue<T> => T.MaxValue - T.One;

            AddRandomValueType(faker => faker.Random.SByte(MinNegative<sbyte>(), MaxNegative<sbyte>()), "negative");
            AddRandomValueType(faker => faker.Random.SByte(MinPositive<sbyte>(), MaxPositive<sbyte>()), "positive");
            AddRandomValueType(faker => faker.Random.Byte(MinPositive<byte>(), MaxPositive<byte>()));

            AddRandomValueType(faker => faker.Random.Short(MinNegative<short>(), MaxNegative<short>()), "negative");
            AddRandomValueType(faker => faker.Random.Short(MinPositive<short>(), MaxPositive<short>()), "positive");
            AddRandomValueType(faker => faker.Random.UShort(MinPositive<ushort>(), MaxPositive<ushort>()));

            AddRandomValueType(faker => faker.Random.Int(MinNegative<int>(), MaxNegative<int>()), "negative");
            AddRandomValueType(faker => faker.Random.Int(MinPositive<int>(), MaxPositive<int>()), "positive");
            AddRandomValueType(faker => faker.Random.UInt(MinPositive<uint>(), MaxPositive<uint>()));

            AddRandomValueType(faker => faker.Random.Long(MinNegative<long>(), MaxNegative<long>()), "negative");
            AddRandomValueType(faker => faker.Random.Long(MinPositive<long>(), MaxPositive<long>()), "positive");
            AddRandomValueType(faker => faker.Random.ULong(MinPositive<ulong>(), MaxPositive<ulong>()));

            AddRandomValueType(faker => faker.Random.Float(), "positive");
            AddRandomValueType(faker => -faker.Random.Float(), "negative");

            AddRandomValueType(faker => faker.Random.Double(), "positive");
            AddRandomValueType(faker => -faker.Random.Double(), "negative");

            AddRandomValueType(faker => faker.Random.Decimal(), "positive");
            AddRandomValueType(faker => -faker.Random.Decimal(), "negative");

            return this;
        }

        public TheoryDataBuilder AddStaticDateTimeSource() =>
            AddValueType(DateTime.MinValue).AddValueType(DateTime.MaxValue);

        public TheoryDataBuilder AddRandomDateTimeSource() =>
            AddRandomValueType(faker => faker.Date.Soon());

        public TheoryDataBuilder AddStaticDateTimeOffsetSource() =>
            AddValueType(DateTimeOffset.MinValue).AddValueType(DateTimeOffset.MaxValue);

        public TheoryDataBuilder AddRandomDateTimeOffsetSource() =>
            AddRandomValueType(faker => faker.Date.SoonOffset());

        public TheoryDataBuilder AddGuidSource() =>
            AddRandomValueType(faker => faker.Random.Guid());

        public TheoryDataBuilder AddSampleEnumSource() =>
            AddRandomValueType(faker => faker.Random.Enum<SampleEnum>());

        public TheoryDataBuilder AddSampleValueTypeSource() =>
            AddRandomValueType(faker => new SampleStruct(faker.Random.Int()));

        private TheoryDataBuilder AddValueType<T>(T value)
            where T : struct
        {
            Add(Value<T>.FromValue(value));
            Add(Value<T?>.FromValue(value));

            return this;
        }

        private TheoryDataBuilder AddRandomValueType<T>(
            Func<Faker, T> factory,
            string additionalInfo = "-")
            where T : struct
        {
            Add(Value<T>.FromRandom(factory, additionalInfo));
            Add(Value<T?>.FromRandom(faker => factory(faker), additionalInfo));

            return this;
        }

        public TheoryDataBuilder AddStringSource()
        {
            Add(Value<string>.FromRandom(faker => faker.Random.String2(0, 10)));

            return this;
        }

        public TheoryDataBuilder AddByteArraySource()
        {
            Add(Value<byte[]>.FromRandom(faker => faker.Random.Bytes(20)));

            return this;
        }

        public TheoryDataBuilder AddSampleRefTypeSource()
        {
            Add(Value<SampleClass>.FromRandom(faker => new SampleClass(faker.Random.Int())));

            return this;
        }
    }

    public enum SampleEnum
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public readonly struct SampleStruct
    {
        private readonly int _value;

        public SampleStruct(int value)
        {
            _value = value;
        }

        public override string ToString() => $"struct value is {_value}";
    }

    public readonly struct SampleClass
    {
        private readonly int _value;

        public SampleClass(int value)
        {
            _value = value;
        }

        public override string ToString() => $"class value is {_value}";
    }
}