using GraphQL.Types;
using MyGraphQl.Api.GraphQl.Queries;

namespace MyGraphQl.Api.GraphQl;

public class MyGraphQlSchema : Schema
{
    public MyGraphQlSchema(IServiceProvider serviceProvider)
    {
        this.Query = serviceProvider.GetRequiredService<MyGraphQlQuery>();
        this.Description = "Example MyGraphQlSchema schema";
    }
}
