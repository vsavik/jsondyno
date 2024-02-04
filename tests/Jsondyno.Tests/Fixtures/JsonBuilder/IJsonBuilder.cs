namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IJsonBuilder : IPrimitiveBuilder<IJsonResult>
{
    IArrayBuilder<IJsonResult> ArrayStart();

    IObjectBuilder<IJsonResult> ObjectStart();
}