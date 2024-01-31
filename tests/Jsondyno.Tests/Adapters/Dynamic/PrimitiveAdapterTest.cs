using Jsondyno.Adapters;
using Jsondyno.Adapters.Dynamic;

namespace Jsondyno.Tests.Adapters.Dynamic;

public sealed class PrimitiveAdapterTest
{
    private static readonly DateTimeOffset s_refDate = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

    private readonly DynamicAdapterFixture<IPrimitive> _fixture = new();

    private readonly dynamic _adapter;

    private readonly Faker _faker;

    public PrimitiveAdapterTest(ITestOutputHelper output)
    {
        _adapter = new PrimitiveAdapter(_fixture.Mock.Object);
        _faker = Factory.CreateFaker(output);
    }

    [Fact]
    public void CastToBoolean()
    {
        // Arrange
        bool expected = _faker.Random.Bool();
        _fixture.SetupCast(x => x.GetBoolean(), expected);

        // Act
        bool actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetBoolean());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableBoolean()
    {
        // Arrange
        bool expected = _faker.Random.Bool();
        _fixture.SetupCast(x => x.GetBoolean(), expected);

        // Act
        bool? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetBoolean());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToByte()
    {
        // Arrange
        byte expected = _faker.Random.Byte();
        _fixture.SetupCast(x => x.GetByte(), expected);

        // Act
        byte actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetByte());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableByte()
    {
        // Arrange
        byte expected = _faker.Random.Byte();
        _fixture.SetupCast(x => x.GetByte(), expected);

        // Act
        byte? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetByte());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToInt16()
    {
        // Arrange
        short expected = _faker.Random.Short();
        _fixture.SetupCast(x => x.GetInt16(), expected);

        // Act
        short actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt16());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableInt16()
    {
        // Arrange
        short expected = _faker.Random.Short();
        _fixture.SetupCast(x => x.GetInt16(), expected);

        // Act
        short? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt16());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToInt32()
    {
        // Arrange
        int expected = _faker.Random.Int();
        _fixture.SetupCast(x => x.GetInt32(), expected);

        // Act
        int actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt32());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableInt32()
    {
        // Arrange
        int expected = _faker.Random.Int();
        _fixture.SetupCast(x => x.GetInt32(), expected);

        // Act
        int? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt32());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToInt64()
    {
        // Arrange
        long expected = _faker.Random.Long();
        _fixture.SetupCast(x => x.GetInt64(), expected);

        // Act
        long actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt64());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableInt64()
    {
        // Arrange
        long expected = _faker.Random.Long();
        _fixture.SetupCast(x => x.GetInt64(), expected);

        // Act
        long? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetInt64());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToSByte()
    {
        // Arrange
        sbyte expected = _faker.Random.SByte();
        _fixture.SetupCast(x => x.GetSByte(), expected);

        // Act
        sbyte actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetSByte());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableSByte()
    {
        // Arrange
        sbyte expected = _faker.Random.SByte();
        _fixture.SetupCast(x => x.GetSByte(), expected);

        // Act
        sbyte? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetSByte());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToUInt16()
    {
        // Arrange
        ushort expected = _faker.Random.UShort();
        _fixture.SetupCast(x => x.GetUInt16(), expected);

        // Act
        ushort actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt16());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableUInt16()
    {
        // Arrange
        ushort expected = _faker.Random.UShort();
        _fixture.SetupCast(x => x.GetUInt16(), expected);

        // Act
        ushort? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt16());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToUInt32()
    {
        // Arrange
        uint expected = _faker.Random.UInt();
        _fixture.SetupCast(x => x.GetUInt32(), expected);

        // Act
        uint actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt32());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableUInt32()
    {
        // Arrange
        uint expected = _faker.Random.UInt();
        _fixture.SetupCast(x => x.GetUInt32(), expected);

        // Act
        uint? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt32());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToUInt64()
    {
        // Arrange
        ulong expected = _faker.Random.ULong();
        _fixture.SetupCast(x => x.GetUInt64(), expected);

        // Act
        ulong actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt64());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableUInt64()
    {
        // Arrange
        ulong expected = _faker.Random.ULong();
        _fixture.SetupCast(x => x.GetUInt64(), expected);

        // Act
        ulong? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetUInt64());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToSingle()
    {
        // Arrange
        float expected = _faker.Random.Float();
        _fixture.SetupCast(x => x.GetSingle(), expected);

        // Act
        float actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetSingle());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableSingle()
    {
        // Arrange
        float expected = _faker.Random.Float();
        _fixture.SetupCast(x => x.GetSingle(), expected);

        // Act
        float? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetSingle());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToDouble()
    {
        // Arrange
        double expected = _faker.Random.Double();
        _fixture.SetupCast(x => x.GetDouble(), expected);

        // Act
        double actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDouble());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableDouble()
    {
        // Arrange
        double expected = _faker.Random.Double();
        _fixture.SetupCast(x => x.GetDouble(), expected);

        // Act
        double? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDouble());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToDecimal()
    {
        // Arrange
        decimal expected = _faker.Random.Decimal();
        _fixture.SetupCast(x => x.GetDecimal(), expected);

        // Act
        decimal actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDecimal());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableDecimal()
    {
        // Arrange
        decimal expected = _faker.Random.Decimal();
        _fixture.SetupCast(x => x.GetDecimal(), expected);

        // Act
        decimal? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDecimal());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToString()
    {
        // Arrange
        string expected = _faker.Lorem.Word();
        _fixture.SetupCast(x => x.GetString(), expected);

        // Act
        string actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetString());
        actual.ShouldBe(expected);
    }


    [Fact]
    public void CastToGuid()
    {
        // Arrange
        Guid expected = _faker.Random.Uuid();
        _fixture.SetupCast(x => x.GetGuid(), expected);

        // Act
        Guid actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetGuid());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableGuid()
    {
        // Arrange
        Guid expected = _faker.Random.Uuid();
        _fixture.SetupCast(x => x.GetGuid(), expected);

        // Act
        Guid? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetGuid());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToDateTime()
    {
        // Arrange
        DateTime expected = _faker.Date.Past(refDate: s_refDate.DateTime);
        _fixture.SetupCast(x => x.GetDateTime(), expected);

        // Act
        DateTime actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDateTime());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableDateTime()
    {
        // Arrange
        DateTime expected = _faker.Date.Past(refDate: s_refDate.DateTime);
        _fixture.SetupCast(x => x.GetDateTime(), expected);

        // Act
        DateTime? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDateTime());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToDateTimeOffset()
    {
        // Arrange
        DateTimeOffset expected = _faker.Date.PastOffset(refDate: s_refDate);
        _fixture.SetupCast(x => x.GetDateTimeOffset(), expected);

        // Act
        DateTimeOffset actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDateTimeOffset());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToNullableDateTimeOffset()
    {
        // Arrange
        DateTimeOffset expected = _faker.Date.PastOffset(refDate: s_refDate);
        _fixture.SetupCast(x => x.GetDateTimeOffset(), expected);

        // Act
        DateTimeOffset? actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetDateTimeOffset());
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void CastToBase64ByteArray()
    {
        // Arrange
        byte[] expected = _faker.Random.Bytes(16);
        _fixture.SetupCast(x => x.GetBytesFromBase64(), expected);

        // Act
        byte[] actual = _adapter;

        // Assert
        _fixture.VerifyCast(x => x.GetBytesFromBase64());
        actual.ShouldBe(expected);
    }

    [Fact]
    public void ConvertToEnum()
    {
        // Arrange
        SampleEnum expected = _faker.Random.Enum<SampleEnum>();
        _fixture.SetupConvert(expected);

        // Act
        SampleEnum actual = _adapter;

        // Assert
        _fixture.VerifyConvert();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void ConvertToNullableEnum()
    {
        // Arrange
        SampleEnum? expected = _faker.Random.Enum<SampleEnum>();
        _fixture.SetupConvert(expected);

        // Act
        SampleEnum? actual = _adapter;

        // Assert
        _fixture.VerifyConvert();
        actual.ShouldNotBeNull();
        actual.ShouldBe(expected);
    }

    private enum SampleEnum
    {
        None = 0,
        Value1,
        Value2,
        Value3
    }
}