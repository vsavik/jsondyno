namespace Jsondyno.Tests.Misc;

internal static class AdapterExtensions
{
    public static IJsonValue? ToJsonValue<T>(this T? obj)
        where T : notnull
    {
        if (obj is null)
        {
            return null;
        }

        var stub = new DynamicStub<T>(obj);
        var itemMock = new Mock<IJsonValue>(MockBehavior.Strict);
        itemMock.Setup(jsonValue => jsonValue.ToDynamic()).Returns(stub);

        return itemMock.Object;
    }
}