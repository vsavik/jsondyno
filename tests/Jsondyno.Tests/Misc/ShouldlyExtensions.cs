namespace Jsondyno.Tests.Misc;

[ShouldlyMethods]
public static class ShouldlyExtensions
{
    public static void ShouldBeJsonString(this in JsonElement? actualElement, string? expectedJson)
    {
        if (expectedJson is null)
        {
            actualElement.ShouldBeNull();
        }
        else
        {
            actualElement.ShouldNotBeNull();
            actualElement.Value.GetRawText().ShouldBe(expectedJson);
        }
    }

    public static void ShouldBeJsonString(this JsonNode? actualNode, string? expectedJson)
    {
        if (expectedJson is null)
        {
            actualNode.ShouldBeNull();
        }
        else
        {
            actualNode.ShouldNotBeNull();
            actualNode.ToJsonString().ShouldBe(expectedJson);
        }
    }
}