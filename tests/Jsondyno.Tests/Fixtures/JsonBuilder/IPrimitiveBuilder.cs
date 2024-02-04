namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IPrimitiveBuilder
{
    private protected void WriteNull();

    private protected void WriteBoolean(bool boolean);

    private protected void WriteNumber(int number);

    private protected void WriteNumber(double number);

    private protected void WriteString(string str);
}

internal interface IPrimitiveBuilder<out TSelf> : IPrimitiveBuilder, IIndent<TSelf>
    where TSelf : ISelfDefinition<TSelf>
{
    TSelf Null()
    {
        WriteNull();

        return Self;
    }

    TSelf Boolean(bool boolean)
    {
        WriteBoolean(boolean);

        return Self;
    }

    TSelf True()
    {
        WriteBoolean(true);

        return Self;
    }

    TSelf False()
    {
        WriteBoolean(false);

        return Self;
    }

    TSelf Number(int number)
    {
        WriteNumber(number);

        return Self;
    }

    TSelf Number(double number)
    {
        WriteNumber(number);

        return Self;
    }

    TSelf String(string str)
    {
        WriteString(str);

        return Self;
    }
}