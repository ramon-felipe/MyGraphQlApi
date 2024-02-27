using GraphQL.Types;
using MyGraphQl.Domain;

namespace MyGraphQl.Api.Interfaces;

public class BaseEntityWithNameInterface : InterfaceGraphType<BaseEntityWithName>
{
    public BaseEntityWithNameInterface()
    {
        this.Name = "BaseEntityWithName";

        this.Field(_ => _.Id);
        this.Field(_ => _.Name);
    }
}