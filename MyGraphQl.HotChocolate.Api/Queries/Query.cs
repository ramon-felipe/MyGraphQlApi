using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.HotChocolate.Api.DataLoaders;
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

/// <summary>
/// The main query
/// </summary>
public class CodeFirstQuery
{
    /// <summary>
    /// Gets an user by its ID.
    /// </summary>
    /// <param name="ctx">The Graphql context</param>
    /// <param name="id">The <see cref="User"/> ID</param>
    /// <returns>A <see cref="User"/> when found or null when not found.</returns>
    public User? GetUser([Service(ServiceKind.Synchronized)] IMyGraphQlContext ctx, int id)
        => ctx.Users.AsNoTracking().SingleOrDefault(_ => _.Id == id);

    /// <summary>
    /// Gets an user by its ID
    /// </summary>
    /// <param name="id">The user ID.</param>
    /// <param name="dataLoader"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<User> GetUserDataLoader(int id, UserBatchDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

    /// <summary>
    /// Gets all the users.
    /// </summary>
    /// <param name="ctx">The Graphql context</param>
    /// <returns>All users</returns>
    public IQueryable<User> GetUsers([Service(ServiceKind.Synchronized)] IMyGraphQlContext ctx)
        => ctx.Users.AsNoTracking().Include(_ => _.UserProcesses);

    /// <summary>
    /// Gets all the processes
    /// </summary>
    /// <param name="ctx">The Graphql context</param>
    /// <returns>All processes</returns>
    public IQueryable<Process> GetProcesses([Service(ServiceKind.Synchronized)] IMyGraphQlContext ctx)
        => ctx.Processes.AsNoTracking().Include(_ => _.UserProcesses);
}

/// <summary>
/// The main query
/// </summary>
public class QueryType : ObjectType<CodeFirstQuery>
{    
    protected override void Configure(IObjectTypeDescriptor<CodeFirstQuery> descriptor)
    {
        descriptor.Description("The main query");

        descriptor
            .Field(_ => _.GetUser(default!, default))
            .Argument("id", _ => _.Type<NonNullType<IntType>>())
            .Description("Gets a user by its ID.");

        descriptor
            .Field(_ => _.GetUsers(default!))
            .Type<UserType>()
            .Description("Gets all the users");

        descriptor
            .Field(_ => _.GetUsers(default!))
            .Type<ProcessType>();
    }
}