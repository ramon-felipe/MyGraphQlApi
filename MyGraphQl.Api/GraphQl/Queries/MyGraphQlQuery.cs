using GraphQL.Types;
using MyGraphQl.Api.GraphQl.Types;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Api.GraphQl.Queries;

public class MyGraphQlQuery : ObjectGraphType
{
    public MyGraphQlQuery(GenericRepository<User> genericRepository)
    {
    }

    public MyGraphQlQuery()
    {
        this.Field<UserType>("users")
            .Resolve(ctx => new User { Id = 1, Name = "Ramon" });
    }
}
