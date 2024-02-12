using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Api.GraphQl.Types;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.Api.GraphQl.Queries;

public class MyGraphQlQuery : ObjectGraphType
{
    public MyGraphQlQuery(IMyGraphQlContext myCtx)
    {
        this.Field<ListGraphType<UserType>>("users")
            .Resolve(ctx => myCtx.Users.AsNoTracking()/*.Include(_ => _.UserProcesses)*/);

        //this.Field<UserType>("user")
        //    .Argument<IdGraphType>("id")
        //    .Resolve(ctx =>
        //    {
        //        var id = ctx.GetArgument<int>("id");
        //        return myCtx.Users.FirstOrDefault(_ => _.Id == id);
        //    });

        this.Field<ListGraphType<ProcessType>>("processes")
            .Resolve(ctx => myCtx.Processes.AsNoTracking());

        // when using scoped lifetime services
        // like the EF default AddDbContext
        //this.Field<UserType>("users")
        //    .Resolve()
        //    .WithScope()
        //    .WithService<IGenericRepository<User>>()
        //    .ResolveAsync(async (ctx, service) => await service.GetByIdAsync(1));
    }
}