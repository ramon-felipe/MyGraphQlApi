using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure;

namespace MyGraphQl.Api.GraphQl.Types;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        this.Field(_ => _.Id);
        this.Field(_ => _.Age);
        this.Field(_ => _.Name);
        this.Field(_ => _.LastName);

        this.Field<ListGraphType<UserProcessType>>("userProcesses")
            .Resolve()
            .WithScope()
            .WithService<IMyGraphQlContext>()
            .Resolve((ctx, service) => service.ProcessUserMapping.AsNoTracking().Where(_ => _.UserId == ctx.Source.Id).ToList());
    }
}

public class UserProcessType : ObjectGraphType<ProcessUserMapping>
{
    public UserProcessType(/*IMyGraphQlContext myCtx*/)
    {
        this.Field(_ => _.UserId);
        this.Field(_ => _.ProcessId);
        this.Field(_ => _.HasAccess);
        //this.Field(_ => _.Process);
        
        //this.Field<UserType, User>("user").Resolve(ctx => myCtx.Users.FirstOrDefault(_ => _.Id == ctx.Source.UserId));
    }
}