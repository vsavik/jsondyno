using System.Numerics;
using System.Reflection;
using AutoFixture.Xunit2;

namespace Jsondyno.Tests.Misc;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class RandomNumberAttribute<TNumber> : CustomizeAttribute
    where TNumber : INumber<TNumber>, IMinMaxValue<TNumber>
{
    public TNumber Min { get; init; } = TNumber.MinValue;

    public TNumber Max { get; init; } = TNumber.MaxValue;

    public override ICustomization GetCustomization(ParameterInfo parameter) =>
        new MinMaxParameterCustomization<TNumber>(parameter, Min, Max);
}