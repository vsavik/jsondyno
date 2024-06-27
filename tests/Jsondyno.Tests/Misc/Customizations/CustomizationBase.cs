using AutoFixture.Kernel;

namespace Jsondyno.Tests.Misc.Customizations;

public abstract class CustomizationBase<T> : ICustomization, IFactory<T>
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(AsFunc(Generate));
        fixture.Inject<IFactory<T>>(this);
    }

    public T CreateValue(ISpecimenContext context)
    {
        Faker faker = context.Create<Faker>();

        return Generate(faker);
    }

    protected abstract T Generate(Faker faker);

    private static TFunc AsFunc<TFunc>(TFunc function) where TFunc : Delegate => function;
}