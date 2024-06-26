using System.Reflection;

namespace Jsondyno.Tests.Misc;

public interface IParameterCustomization
{
    static abstract ICustomization Create(ParameterInfo parameter);
}