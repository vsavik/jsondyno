namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IIndent<out TSelf> : ISelfDefinition<TSelf>
    where TSelf : ISelfDefinition<TSelf>
{
    TSelf ___ => Self;
}