namespace Jsondyno.Tests.Misc;

public sealed class AdapterCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(FakerCustomization.Current);
        fixture.Inject<JsonNamingPolicy?>(null);
        fixture.Register((Faker faker) => new RandomArrayItems(faker));
        fixture.Register((IJsonValue jsonValue) => new PrimitiveAdapter(jsonValue));
        fixture.Register((IJsonArray jsonArray) => new ArrayAdapter(jsonArray));
        fixture.Register((IJsonObject jsonObject, JsonNamingPolicy? policy) =>
            new ObjectAdapter(jsonObject, policy));
    }
}