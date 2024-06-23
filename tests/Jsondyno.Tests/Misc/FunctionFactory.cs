namespace Jsondyno.Tests.Misc;

internal static class FunctionFactory
{
    // This function provides type inference for Fixture.Register
    public static T AsFunc<T>(T function) => function;
}