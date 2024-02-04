namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IPrimitiveBuilder
{
    private protected void WriteNull();

    private protected void WriteNumber(int number);
}

internal interface IPrimitiveBuilder<out TSelf> : IPrimitiveBuilder, IIndent<TSelf>
    where TSelf : ISelfDefinition<TSelf>
{
    TSelf Null()
    {
        WriteNull();

        return Self;
    }

    TSelf Number(int number)
    {
        WriteNumber(number);

        return Self;
    }
}