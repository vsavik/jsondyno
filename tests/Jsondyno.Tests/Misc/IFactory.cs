using AutoFixture.Kernel;

namespace Jsondyno.Tests.Misc;

public interface IFactory
{
    object? Create(ISpecimenContext context);
}

public interface IFactory<out T> : IFactory
{
    T CreateValue(ISpecimenContext context);

    object? IFactory.Create(ISpecimenContext context) => CreateValue(context);
}