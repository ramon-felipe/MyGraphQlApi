using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using MyGraphQl.Domain;
using MyGraphQl.HotChocolate.Api.Types;
using MyGraphQl.Infrastructure;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.HotChocolate.Api.Queries;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> UsersCtx([Service] IMyGraphQlContext ctx) => ctx.Users.AsNoTracking().Include(_ => _.UserProcesses).ThenInclude(_ => _.Process);
    public IQueryable<Process> ProcessesCtx([Service] IMyGraphQlContext ctx) => ctx.Processes.AsNoTracking().Include(_ => _.UserProcesses).ThenInclude(_ => _.User);

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ProcessUserMapping> ProcessUserMapping([Service] IMyGraphQlContext ctx) => ctx.ProcessUserMapping.AsNoTracking().Include(_ => _.User).Include(_ => _.Process);

    public Task<IEnumerable<User>> Users([Service(ServiceKind.Synchronized)] IGenericRepository<User> ctx) => ctx.GetAllAsync(includeExpressions: _ => _.UserProcesses);

    public Task<IEnumerable<Process>> Processes([Service(ServiceKind.Synchronized)] IGenericRepository<Process> ctx) => ctx.GetAllAsync();
}

public class NewQuery
{
    public IQueryable<User> GetUsers([Service] IMyGraphQlContext ctx)
    {
        return ctx.Users.AsNoTracking().Include(_ => _.UserProcesses);
    }
}

public class QueryType : ObjectType<NewQuery>
{
    protected override void Configure(IObjectTypeDescriptor<NewQuery> descriptor)
    {
        descriptor
            .Field(_ => _.GetUsers(default!))
            .Type<UserType>();
    }
}