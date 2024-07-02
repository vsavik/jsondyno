namespace Jsondyno.Tests.Misc;

public sealed class FakerCustomization : ICustomization
{
    private readonly Faker _faker = new();

    private FakerCustomization()
    {
    }

    public void Customize(IFixture fixture)
    {
        fixture.Inject(_faker);
    }

    public static FakerCustomization Current { get; } = new();
}