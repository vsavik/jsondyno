using System.Numerics;

namespace Jsondyno.Tests.Dynamic;

/*
partial class PrimitiveAdapterTestFixture
{

        public TheoryDataBuilder AddStaticDateTimeSource() =>
            AddValueType(DateTime.MinValue).AddValueType(DateTime.MaxValue);

        public TheoryDataBuilder AddRandomDateTimeSource() =>
            AddRandomValueType(faker => faker.Date.Soon(100, new DateTime(2024, 1, 1)));

        public TheoryDataBuilder AddStaticDateTimeOffsetSource() =>
            AddValueType(DateTimeOffset.MinValue).AddValueType(DateTimeOffset.MaxValue);

        public TheoryDataBuilder AddRandomDateTimeOffsetSource() =>
            AddRandomValueType(faker => faker.Date.SoonOffset(100, new DateTime(2024, 1, 1)));

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
    */