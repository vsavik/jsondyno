namespace Jsondyno.Tests.Misc;

[ShouldlyMethods]
public static class ShouldlyExtensions
{
    public static void ShouldBeJsonString(this in JsonElement? element, string? expectedJson)
    {
        if (expectedJson is null)
        {
            element.ShouldBeNull();
        }
        else
        {
            element.ShouldNotBeNull();
            element.Value.GetRawText().ShouldBe(expectedJson);
        }
    }
}