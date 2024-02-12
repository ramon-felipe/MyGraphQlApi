using GraphQL.Types;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;
using MyGraphQl.Infrastructure.Repositories;

namespace MyGraphQl.Api.GraphQl.Types;

public class UserType : ObjectGraphType<User>
{
    public UserType(/*IGenericRepository<ProcessUserMapping> repo*/)
    {
        this.Field(_ => _.Id);
        this.Field(_ => _.Age);
        this.Field(_ => _.Name);
        this.Field(_ => _.LastName);

        //this.Field<ListGraphType<UserProcessType>, IEnumerable<ProcessUserMapping>>("userProcesses")
        //    .ResolveAsync(async ctx => await repo.GetAllAsync(conditionExpressions: [_ => _.UserId == ctx.Source.Id]));
    }
}

public class UserProcessType : ObjectGraphType<ProcessUserMapping>
{
    public UserProcessType(/*IMyGraphQlContext myCtx*/)
    {
        this.Field(_ => _.UserId);
        this.Field(_ => _.ProcessId);
        //this.Field(_ => _.Process);
        
        //this.Field<UserType, User>("user").Resolve(ctx => myCtx.Users.FirstOrDefault(_ => _.Id == ctx.Source.UserId));
    }
}