using Jsondyno.Internal;

namespace Jsondyno.Tests.Dynamic.Auxiliary;

internal static class MockExtensions
{
    public static void SetExpectedArraySize(
        this Mock<IJsonArray> mock,
        int expectedArraySize)
    {
        mock.Setup(jsonArray => jsonArray.GetLength())
            .Returns(expectedArraySize)
            .Verifiable(Times.Once, "Caching doesn't work.");
    }

    public static void SetExpectedArray(
        this Mock<IJsonArray> mock,
        string[] expectedArray)
    {
        mock.Setup(jsonArray => jsonArray.Deserialize(typeof(string[]), It.IsAny<JsonSerializerOptions>()))
            .Returns(expectedArray)
            .Verifiable(Times.Once);
    }

    public static void SetExpectedArrayItems(
        this Mock<IJsonArray> mock,
        int index1,
        int index2,
        string item1,
        string item2)
    {
        mock.Setup(jsonArray => jsonArray.GetArrayElement(index1))
            .Returns(CreateJsonValueMock(item1))
            .Verifiable(Times.Exactly(2));

        mock.Setup(jsonArray => jsonArray.GetArrayElement(index2))
            .Returns(CreateJsonValueMock(item2))
            .Verifiable(Times.Once);
    }

    private static IJsonValue CreateJsonValueMock(string expected)
    {
        var mock = new Mock<IJsonValue>(MockBehavior.Strict);
        mock.Setup(jsonValue => jsonValue.ToDynamic(It.IsAny<Context>()))
            .Returns(expected);

        return mock.Object;
    }

    public static void SetExpectedValue<T>(
        this Mock<IJsonValue> mock,
        T expected)
    {
        mock.Setup(jsonValue => jsonValue.Deserialize(typeof(T), It.IsAny<JsonSerializerOptions>()))
            .Returns(expected)
            .Verifiable(Times.Once, "Caching doesn't work.");
    }
}