using System.Reflection;
using Xunit.Sdk;

namespace Jsondyno.Tests.Misc;

[CLSCompliant(false)]
[DataDiscoverer("Xunit.Sdk.MemberDataDiscoverer", "xunit.core")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class MemberDataAttribute<T> : MemberDataAttributeBase
{
    public MemberDataAttribute(string memberName)
        : base(memberName, [])
    {
        MemberType = typeof(T);
    }

    protected override object[]? ConvertDataItem(MethodInfo testMethod, object item) =>
        item as object[];
}