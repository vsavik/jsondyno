using System.Reflection;
using AutoFixture.Kernel;

namespace Jsondyno.Tests.Misc;

public abstract class ParameterCustomization<T> : ICustomization, ISpecimenBuilder
{
    private readonly ParameterInfo _parameter;

    protected ParameterCustomization(ParameterInfo parameter)
    {
        _parameter = parameter;
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(this);
    }

    public object? Create(object request, ISpecimenContext context)
    {
        if (_parameter.Equals(request))
        {
            return CreateParameterValue(context);
        }

        return new NoSpecimen();
    }

    protected abstract T CreateParameterValue(ISpecimenContext context);
}