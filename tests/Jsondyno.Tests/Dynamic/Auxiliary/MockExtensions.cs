namespace Jsondyno.Tests.Dynamic.Auxiliary;

internal static class MockExtensions
{
    public static void InjectArraySize(this Mock<IJsonArray> mock, int size)
    {
        mock.Setup(jsonArray => jsonArray.GetLength())
            .Returns(size)
            .Verifiable(Times.Once, "Caching doesn't work.");
    }

    public static void InjectConvertTarget<TMock, TData>(
        this Mock<TMock> mock,
        JsonSerializerOptions opts,
        TData data)
        where TMock : class, IJsonValue
    {
        mock.Setup(jsonValue => jsonValue.Deserialize(typeof(TData), opts))
            .Returns(data)
            .Verifiable(Times.Once);
    }

    public static void InjectArrayItems(
        this Mock<IJsonArray> mock,
        ArrayItem item1,
        ArrayItem item2)
    {
        mock.Setup(jsonArray => jsonArray.GetArrayElement(item1.Index))
            .Returns(CreateJsonValueMock(item1.Value))
            .Verifiable(Times.Exactly(2));

        mock.Setup(jsonArray => jsonArray.GetArrayElement(item2.Index))
            .Returns(CreateJsonValueMock(item2.Value))
            .Verifiable(Times.Once);
    }

    private static IJsonValue CreateJsonValueMock(string expected)
    {
        var mock = new Mock<IJsonValue>(MockBehavior.Strict);
        mock.Setup(jsonValue => jsonValue.ToDynamic(It.IsAny<Context>()))
            .Returns(expected);

        return mock.Object;
    }
}