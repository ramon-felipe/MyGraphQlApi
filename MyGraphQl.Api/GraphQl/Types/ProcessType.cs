using GraphQL.Types;
using MyGraphQl.Domain;

namespace MyGraphQl.Api.GraphQl.Types;

public class ProcessType : ObjectGraphType<Process>
{
    public ProcessType()
    {
        this.Field(_ => _.Id);
        this.Field(_ => _.Name);
        // this.Field(_ => _.UserProcesses);
    }
}