using System.Numerics;
using System.Reflection;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;

namespace Jsondyno.Tests.Misc;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class RandomNumberAttribute<TNumber> : CustomizeAttribute
    where TNumber : INumber<TNumber>, IMinMaxValue<TNumber>
{
    public TNumber Min { get; init; } = TNumber.MinValue;

    public TNumber Max { get; init; } = TNumber.MaxValue;

    public override ICustomization GetCustomization(ParameterInfo parameter) =>
        new RandomBetween(parameter, Min, Max);

    private sealed class RandomBetween : ICustomization, ISpecimenBuilder
    {
        private readonly ParameterInfo _parameter;

        private readonly TNumber _min;

        private readonly TNumber _max;

        public RandomBetween(ParameterInfo parameter, TNumber min, TNumber max)
        {
            _parameter = parameter;
            _min = min;
            _max = max;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(this);
        }

        public object Create(object request, ISpecimenContext context)
        {
            if (_parameter.Equals(request))
            {
                var generator = context.Create<GenerateRandomBetweenDelegate<TNumber>>();

                return generator(_min, _max);
            }

            return new NoSpecimen();
        }
    }
}