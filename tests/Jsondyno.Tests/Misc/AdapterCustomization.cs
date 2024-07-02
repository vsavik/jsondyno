namespace Jsondyno.Tests.Misc;

public sealed class AdapterCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(FakerCustomization.Current);
        fixture.Inject(JsonSerializerOptions.Default);

        fixture.Register((IJsonValue jsonValue) =>
            new PrimitiveAdapter(jsonValue));

        fixture.Register((IJsonArray jsonArray) =>
            new ArrayAdapter(jsonArray));

        fixture.Register((IJsonObject jsonObject) =>
            new ObjectAdapter(jsonObject, JsonNamingPolicy.CamelCase));
    }
}