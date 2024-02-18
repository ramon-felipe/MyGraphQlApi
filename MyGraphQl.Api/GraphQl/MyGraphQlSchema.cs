using MyGraphQl.Api.GraphQl.Queries;

namespace MyGraphQl.Api.GraphQl;

public class MyGraphQlSchema : GraphQL.Types.Schema
{
    public MyGraphQlSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.Query = serviceProvider.GetRequiredService<MyGraphQlQuery>();
        this.Description = "Example MyGraphQlSchema schema";
    }
}
