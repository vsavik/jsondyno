using System.Reflection;
using AutoFixture.Xunit2;

namespace Jsondyno.Tests.Misc;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class CustomizeAttribute<T> : CustomizeAttribute
    where T : IParameterCustomization
{
    public override ICustomization GetCustomization(ParameterInfo parameter) =>
        T.Create(parameter);
}