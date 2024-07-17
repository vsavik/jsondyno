namespace Jsondyno.Tests.Misc;

internal static class FakeExtensions
{
    public static void ClearFakeJsonCalls<T>(this T fake)
        where T : IJsonValue
    {
        Fake.ClearRecordedCalls(fake);
    }
}