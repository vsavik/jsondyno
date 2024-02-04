namespace Jsondyno.Tests.Fixtures.JsonBuilder;

internal interface IObjectBuilder<TParent> : IIndent<IObjectBuilder<TParent>>
{
    IObjectBuilder<TParent> ISelfDefinition<IObjectBuilder<TParent>>.Self => this;

    TParent ObjectEnd();

    IPrimitiveBuilder<IObjectBuilder<TParent>> Property(string propertyName);

    IArrayBuilder<IObjectBuilder<TParent>> ArrayStart(string propertyName);

    IObjectBuilder<IObjectBuilder<TParent>> ObjectStart(string propertyName);
}