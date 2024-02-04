namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IArrayBuilder<TParent> : IPrimitiveBuilder<IArrayBuilder<TParent>>
{
    IArrayBuilder<TParent> ISelfDefinition<IArrayBuilder<TParent>>.Self => this;

    TParent ArrayEnd();

    IArrayBuilder<IArrayBuilder<TParent>> ArrayStart();

    IObjectBuilder<IArrayBuilder<TParent>> ObjectStart();
}