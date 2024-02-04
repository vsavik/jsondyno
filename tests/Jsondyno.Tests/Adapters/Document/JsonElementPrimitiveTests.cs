using System.Text;
using Jsondyno.Adapters.Document;
using Jsondyno.Tests.Fixtures.JsonBuilder;

namespace Jsondyno.Tests.Adapters.Document;

public sealed class JsonElementPrimitiveTests :
    IClassFixture<FakerFixture>,
    IDisposable
{
    private readonly JsonFixture _json = new();

    private readonly Faker _faker;

    private JsonElementPrimitive? _primitive;

    public JsonElementPrimitiveTests(
        FakerFixture faker,
        ITestOutputHelper output)
    {
        _faker = faker;

        output.WriteLine($"Initializing Faker with seed: {faker.Seed}");
    }

    private JsonElementPrimitive Sut => _primitive ??= _json.CreateJsonElementPrimitive();

    [Fact]
    public void GetBoolean()
    {
        // Arrange
        bool expected = _faker.Random.Bool();
        _json.Builder.Boolean(expected);

        // Act
        bool actual = Sut.GetBoolean();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetByte()
    {
        // Arrange
        byte expected = _faker.Random.Byte();
        _json.Builder.Number(expected);

        // Act
        byte actual = Sut.GetByte();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetInt16()
    {
        // Arrange
        short expected = _faker.Random.Short();
        _json.Builder.Number(expected);

        // Act
        short actual = Sut.GetInt16();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetInt32()
    {
        // Arrange
        int expected = _faker.Random.Int();
        _json.Builder.Number(expected);

        // Act
        int actual = Sut.GetInt32();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetInt64()
    {
        // Arrange
        long expected = _faker.Random.Long(Int32.MinValue, Int32.MaxValue);
        _json.Builder.Number(expected);

        // Act
        long actual = Sut.GetInt64();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetSByte()
    {
        // Arrange
        sbyte expected = _faker.Random.SByte();
        _json.Builder.Number(expected);

        // Act
        sbyte actual = Sut.GetSByte();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetUInt16()
    {
        // Arrange
        ushort expected = _faker.Random.UShort();
        _json.Builder.Number(expected);

        // Act
        ushort actual = Sut.GetUInt16();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetUInt32()
    {
        // Arrange
        uint expected = _faker.Random.UInt();
        _json.Builder.Number(expected);

        // Act
        uint actual = Sut.GetUInt32();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetUInt64()
    {
        // Arrange
        ulong expected = _faker.Random.ULong();
        _json.Builder.Number(expected);

        // Act
        ulong actual = Sut.GetUInt64();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetSingle()
    {
        // Arrange
        float expected = _faker.Random.Float();
        _json.Builder.Number(expected);

        // Act
        float actual = Sut.GetSingle();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetDouble()
    {
        // Arrange
        double expected = _faker.Random.Double();
        _json.Builder.Number(expected);

        // Act
        double actual = Sut.GetDouble();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetDecimal()
    {
        // Arrange
        decimal expected = _faker.Random.Decimal();
        _json.Builder.Number(expected);

        // Act
        decimal actual = Sut.GetDecimal();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetString()
    {
        // Arrange
        string expected = _faker.Random.String2(10);
        _json.Builder.String(expected);

        // Act
        string actual = Sut.GetString();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetGuid()
    {
        // Arrange
        Guid expected = _faker.Random.Guid();
        _json.Builder.String(expected.ToString("D"));

        // Act
        Guid actual = Sut.GetGuid();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetDateTime()
    {
        // Arrange
        DateTime expected = _faker.Date.Between(new DateTime(2020, 1, 1), new DateTime(2024, 1, 1));
        _json.Builder.String(expected.ToString("O"));

        // Act
        DateTime actual = Sut.GetDateTime();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetDateTimeOffset()
    {
        // Arrange
        DateTimeOffset expected = _faker.Date.Between(new DateTime(2020, 1, 1), new DateTime(2024, 1, 1));
        _json.Builder.String(expected.ToString("O"));

        // Act
        DateTimeOffset actual = Sut.GetDateTimeOffset();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GetBytesFromBase64()
    {
        // Arrange
        byte[] expected = _faker.Random.Bytes(10);
        _json.Builder.String(Convert.ToBase64String(expected));

        // Act
        byte[] actual = Sut.GetBytesFromBase64();

        // Assert
        actual.ShouldBe(expected);
    }

    public void Dispose() => _json.Dispose();
}
