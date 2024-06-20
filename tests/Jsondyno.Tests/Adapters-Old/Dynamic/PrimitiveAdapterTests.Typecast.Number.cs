using System.Numerics;

namespace Jsondyno.Tests.Adapters.Dynamic;

public static partial class PrimitiveAdapterTests
{
    public sealed class TypecastByte : Typecast
    {
        public TypecastByte(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomByte()
        {
            byte expected = Faker.Random.Byte();
            CanGetByte(expected);
        }

        [Fact]
        public void CanGetRandomByteNull()
        {
            byte expected = Faker.Random.Byte();
            CanGetByteNull(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<byte>))]
        public void CanGetByte(byte expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetByte(), expected);

            // Act
            byte actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetByte());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<byte>))]
        public void CanGetByteNull(byte expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetByte(), expected);

            // Act
            byte? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetByte());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastInt16 : Typecast
    {
        public TypecastInt16(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomInt16()
        {
            short expected = Faker.Random.Short();
            CanGetInt16(expected);
        }

        [Fact]
        public void CanGetRandomInt16Null()
        {
            short expected = Faker.Random.Short();
            CanGetInt16Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<short>))]
        public void CanGetInt16(short expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt16(), expected);

            // Act
            short actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt16());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<short>))]
        public void CanGetInt16Null(short expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt16(), expected);

            // Act
            short? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt16());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastInt32 : Typecast
    {
        public TypecastInt32(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomInt32()
        {
            int expected = Faker.Random.Int();
            CanGetInt32(expected);
        }

        [Fact]
        public void CanGetRandomInt32Null()
        {
            int expected = Faker.Random.Int();
            CanGetInt32Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<int>))]
        public void CanGetInt32(int expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt32(), expected);

            // Act
            int actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt32());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<int>))]
        public void CanGetInt32Null(int expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt32(), expected);

            // Act
            int? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt32());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastInt64 : Typecast
    {
        public TypecastInt64(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomInt64()
        {
            long expected = Faker.Random.Long();
            CanGetInt64(expected);
        }

        [Fact]
        public void CanGetRandomInt64Null()
        {
            long expected = Faker.Random.Long();
            CanGetInt64Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<long>))]
        public void CanGetInt64(long expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt64(), expected);

            // Act
            long actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt64());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<long>))]
        public void CanGetInt64Null(long expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetInt64(), expected);

            // Act
            long? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetInt64());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastSByte : Typecast
    {
        public TypecastSByte(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomSByte()
        {
            sbyte expected = Faker.Random.SByte();
            CanGetSByte(expected);
        }

        [Fact]
        public void CanGetRandomSByteNull()
        {
            sbyte expected = Faker.Random.SByte();
            CanGetSByteNull(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<sbyte>))]
        public void CanGetSByte(sbyte expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetSByte(), expected);

            // Act
            sbyte actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetSByte());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<sbyte>))]
        public void CanGetSByteNull(sbyte expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetSByte(), expected);

            // Act
            sbyte? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetSByte());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastUInt16 : Typecast
    {
        public TypecastUInt16(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomUInt16()
        {
            ushort expected = Faker.Random.UShort();
            CanGetUInt16(expected);
        }

        [Fact]
        public void CanGetRandomUInt16Null()
        {
            ushort expected = Faker.Random.UShort();
            CanGetUInt16Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<ushort>))]
        public void CanGetUInt16(ushort expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt16(), expected);

            // Act
            ushort actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt16());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<ushort>))]
        public void CanGetUInt16Null(ushort expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt16(), expected);

            // Act
            ushort? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt16());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastUInt32 : Typecast
    {
        public TypecastUInt32(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomUInt32()
        {
            uint expected = Faker.Random.UInt();
            CanGetUInt32(expected);
        }

        [Fact]
        public void CanGetRandomUInt32Null()
        {
            uint expected = Faker.Random.UInt();
            CanGetUInt32Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<uint>))]
        public void CanGetUInt32(uint expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt32(), expected);

            // Act
            uint actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt32());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<uint>))]
        public void CanGetUInt32Null(uint expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt32(), expected);

            // Act
            uint? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt32());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastUInt64 : Typecast
    {
        public TypecastUInt64(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomUInt64()
        {
            ulong expected = Faker.Random.ULong();
            CanGetUInt64(expected);
        }

        [Fact]
        public void CanGetRandomUInt64Null()
        {
            ulong expected = Faker.Random.ULong();
            CanGetUInt64Null(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<ulong>))]
        public void CanGetUInt64(ulong expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt64(), expected);

            // Act
            ulong actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt64());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<ulong>))]
        public void CanGetUInt64Null(ulong expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetUInt64(), expected);

            // Act
            ulong? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetUInt64());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastSingle : Typecast
    {
        public TypecastSingle(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomSingle()
        {
            float expected = Faker.Random.Float();
            CanGetSingle(expected);
        }

        [Fact]
        public void CanGetRandomSingleNull()
        {
            float expected = Faker.Random.Float();
            CanGetSingleNull(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<float>))]
        public void CanGetSingle(float expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetSingle(), expected);

            // Act
            float actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetSingle());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<float>))]
        public void CanGetSingleNull(float expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetSingle(), expected);

            // Act
            float? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetSingle());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastDouble : Typecast
    {
        public TypecastDouble(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomDouble()
        {
            double expected = Faker.Random.Double();
            CanGetDouble(expected);
        }

        [Fact]
        public void CanGetRandomDoubleNull()
        {
            double expected = Faker.Random.Double();
            CanGetDoubleNull(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<double>))]
        public void CanGetDouble(double expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetDouble(), expected);

            // Act
            double actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDouble());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<double>))]
        public void CanGetDoubleNull(double expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetDouble(), expected);

            // Act
            double? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDouble());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class TypecastDecimal : Typecast
    {
        public TypecastDecimal(FakerFixture faker, ITestOutputHelper output)
            : base(faker, output)
        {
        }

        [Fact]
        public void CanGetRandomDecimal()
        {
            decimal expected = Faker.Random.Decimal();
            CanGetDecimal(expected);
        }

        [Fact]
        public void CanGetRandomDecimalNull()
        {
            decimal expected = Faker.Random.Decimal();
            CanGetDecimalNull(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<decimal>))]
        public void CanGetDecimal(decimal expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetDecimal(), expected);

            // Act
            decimal actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDecimal());
            actual.ShouldBe(expected);
        }

        [Theory]
        [ClassData(typeof(NumberSource<decimal>))]
        public void CanGetDecimalNull(decimal expected)
        {
            // Arrange
            Mock.JsondynoSetupTypecast(x => x.GetDecimal(), expected);

            // Act
            decimal? actual = Adapter;

            // Assert
            Mock.JsondynoVerifyTypecast(x => x.GetDecimal());
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
        }
    }

    public sealed class NumberSource<TNumber> : TheoryData<TNumber>
        where TNumber : INumber<TNumber>, IMinMaxValue<TNumber>
    {
        public NumberSource()
        {
            Add(TNumber.Zero);
            Add(TNumber.One);
            Add(TNumber.MinValue);
            Add(TNumber.MaxValue);
        }
    }
}