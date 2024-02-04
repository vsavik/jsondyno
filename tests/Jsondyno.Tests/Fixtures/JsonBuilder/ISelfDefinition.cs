namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface ISelfDefinition<out TSelf>
    where TSelf : ISelfDefinition<TSelf>
{
    private protected TSelf Self { get; }
}