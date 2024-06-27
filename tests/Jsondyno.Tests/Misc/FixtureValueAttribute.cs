using System.Reflection;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;

namespace Jsondyno.Tests.Misc;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class FixtureValueAttribute<TFactory> : CustomizeAttribute
    where TFactory : IFactory
{
    public override ICustomization GetCustomization(ParameterInfo parameter) =>
        new ParameterValueCustomization(parameter);

    private sealed class ParameterValueCustomization : ICustomization, ISpecimenBuilder
    {
        private readonly ParameterInfo _parameter;

        public ParameterValueCustomization(ParameterInfo parameter)
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
                TFactory factory = context.Create<TFactory>();

                return factory.Create(context);
            }

            return new NoSpecimen();
        }
    }
}