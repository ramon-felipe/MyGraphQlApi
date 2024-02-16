using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Api.GraphQl.Types;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Api.GraphQl.Queries;

public class MyGraphQlQuery : ObjectGraphType
{
    public MyGraphQlQuery()
    {
        // when using scoped lifetime services
        // like the EF default AddDbContext
        this.Field<UserType>("user")
            .Argument<IdGraphType>("id")
            .Resolve()
            .WithScope()
            .WithService<IGenericRepository<User>>()              
            .ResolveAsync(async (ctx, service) =>
            {
                var id = ctx.GetArgument<int>("id");
                return await service.GetByIdAsync(id);
            });

        this.Field<ListGraphType<ProcessType>>("users")
            .Resolve()
            .WithScope()
            .WithService<IMyGraphQlContext>()
            .ResolveAsync(async (ctx, service) => await service.Users.AsNoTracking().ToListAsync());

        this.Field<ListGraphType<ProcessType>>("processes")
            .Resolve()
            .WithScope()
            .WithService<IMyGraphQlContext>()
            .ResolveAsync(async (ctx, service) => await service.Processes.AsNoTracking().ToListAsync());

        // another way of doing the same as above. 
        // using ctx.RequestServices.GetRequiredService<TService>()
        // this.Field<UserType>("user")
        //     .Argument<IdGraphType>("id")
        //     .ResolveAsync(async ctx =>
        //     {
        //         var id = ctx.GetArgument<int>("id");
        //         return await ctx.RequestServices.GetRequiredService<IGenericRepository<User>>().GetByIdAsync(id);
        //     });
    }
}