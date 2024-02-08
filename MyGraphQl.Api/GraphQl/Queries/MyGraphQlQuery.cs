using GraphQL.Types;
using MyGraphQl.Api.GraphQl.Types;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Api.GraphQl.Queries;

public class MyGraphQlQuery : ObjectGraphType
{
    public MyGraphQlQuery(IGenericRepository<User> repository)
    {
        this.Field<UserType>("users")
            .ResolveAsync(async ctx => await repository.GetByIdAsync(1));

        // when using scoped lifetime services
        // like the EF default AddDbContext
        //this.Field<UserType>("users")
        //    .Resolve()
        //    .WithScope()
        //    .WithService<IGenericRepository<User>>()
        //    .ResolveAsync(async (ctx, service) => await service.GetByIdAsync(1));
    }
}
