namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IJsonResult : ISelfDefinition<IJsonResult>
{
    IJsonResult ISelfDefinition<IJsonResult>.Self => this;

    Stream GetStream();

    string GetString();
}