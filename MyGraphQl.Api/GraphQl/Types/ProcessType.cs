using GraphQL.Types;
using MyGraphQl.Api.Interfaces;
using MyGraphQl.Domain;

namespace MyGraphQl.Api.GraphQl.Types;

public class ProcessType : ObjectGraphType<Process>
{
    public ProcessType()
    {
        this.Field(_ => _.Id);
        this.Field(_ => _.Name);
        // this.Field(_ => _.UserProcesses);

        // Basically, it imposes we have to implement all the fields specified in the BaseEntityWithNameInterface
        // on this type
        this.Interface<BaseEntityWithNameInterface>();
    }
}