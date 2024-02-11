using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Api.GraphQl.Queries;

//public class MyGraphQlQuery : ObjectGraphType
//{
//    public MyGraphQlQuery(IGenericRepository<User> repository)
//    {
//        this.Field<UserType>("users")
//            .ResolveAsync(async ctx => await repository.GetByIdAsync(1));

//        // when using scoped lifetime services
//        // like the EF default AddDbContext
//        //this.Field<UserType>("users")
//        //    .Resolve()
//        //    .WithScope()
//        //    .WithService<IGenericRepository<User>>()
//        //    .ResolveAsync(async (ctx, service) => await service.GetByIdAsync(1));
//    }
//}

public class Query
{
    public IQueryable<User> UsersCtx([Service] IMyGraphQlContext ctx) => ctx.Users.AsNoTracking().Include(_ => _.UserProcesses).ThenInclude(_ => _.Process);
    public IQueryable<Process> ProcessesCtx([Service] IMyGraphQlContext ctx) => ctx.Processes.AsNoTracking().Include(_ => _.UserProcesses).ThenInclude(_ => _.User);
    public IQueryable<ProcessUserMapping> ProcessUserMapping([Service] IMyGraphQlContext ctx) => ctx.ProcessUserMapping.AsNoTracking().Include(_ => _.User).Include(_ => _.Process);

    public Task<IEnumerable<User>> Users([Service(ServiceKind.Resolver)] IGenericRepository<User> ctx) => ctx.GetAllAsync(includeExpressions: _ => _.UserProcesses);

    public Task<IEnumerable<Process>> Processes([Service(ServiceKind.Resolver)] IGenericRepository<Process> ctx) => ctx.GetAllAsync();
}