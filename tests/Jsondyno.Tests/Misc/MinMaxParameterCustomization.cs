using System.Reflection;
using AutoFixture.Kernel;

namespace Jsondyno.Tests.Misc;

public sealed class MinMaxParameterCustomization<T> : ParameterCustomization<T>
{
    private readonly T _min;

    private readonly T _max;

    public MinMaxParameterCustomization(ParameterInfo parameter, T min, T max)
        : base(parameter)
    {
        _min = min;
        _max = max;
    }

    protected override T CreateParameterValue(ISpecimenContext context)
    {
        RandomGenerator<T> generator = context.Create<RandomGenerator<T>>();

        return generator(_min, _max);
    }
}